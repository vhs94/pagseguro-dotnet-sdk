using Microsoft.Extensions.Options;
using Pagseguro.Sdk.RecurringPayment.Domain.Entity;
using Pagseguro.Sdk.RecurringPayment.Domain.Interface;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pagseguro.Sdk.RecurringPayment.Infra.Helper
{
    public class HttpHelper : IHttpHelper
    {
        private readonly PagSeguroOptions _options;
        private readonly string _defaultQueryString;

        public HttpHelper(IOptions<PagSeguroOptions> options)
        {
            _options = options.Value;
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["email"] = _options.Email;
            query["token"] = _options.Token;
            _defaultQueryString = query.ToString();
        }
        public async Task<string> CallApi(ApiRequest request)
        {
            var apiUrl = _options.SandboxMode ? ApiConstants.WsSandboxUrl : ApiConstants.WsProdUrl;
            var body = request.Body != null ? JsonConvert.SerializeObject(request.Body) : _defaultQueryString;
            var contentType = request.JsonContent ? "application/json" : "application/xml";

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiUrl);
            using var message = new HttpRequestMessage(request.Method, $"/{request.Resource}?{_defaultQueryString}");
            message.Content = new StringContent(body, Encoding.UTF8, contentType);

            if (request.Accept.HasValue)
                message.AddPagseguroAccept(request.Accept.Value);

            var response = await httpClient.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();


            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(content);

            return content;
        }

        public async Task<TResult> CallApi<TResult>(ApiRequest request)
        {
            var content = await CallApi(request);
            return JsonConvert.DeserializeObject<TResult>(content);
        }
    }
}

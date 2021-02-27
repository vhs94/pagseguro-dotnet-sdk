using Pagseguro.Sdk.RecurringPayment.Application.Inteface;
using Pagseguro.Sdk.RecurringPayment.Domain.Entity;
using Pagseguro.Sdk.RecurringPayment.Domain.Interface;
using Pagseguro.Sdk.RecurringPayment.Infra.Helper;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace Pagseguro.Sdk.RecurringPayment.Application.Service
{
    public class PagseguroSessionService : IPagseguroSessionService
    {
        private readonly IHttpHelper _httpHelper;

        public PagseguroSessionService(IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }
        public async Task<string> NewSession()
        {
            var xmlResponse = await _httpHelper.CallApi(new ApiRequest()
            {
                Method = HttpMethod.Post,
                Resource = ApiConstants.Sessions,
                JsonContent = false,
            });

            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlResponse);
            var sessionElement = xmldoc.GetElementsByTagName("session");
            return sessionElement[0].InnerText;
        }
    }
}

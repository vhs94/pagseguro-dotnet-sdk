using Microsoft.Extensions.Options;
using Pagseguro.Sdk.RecurringPayment.Application.Inteface;
using Pagseguro.Sdk.RecurringPayment.Domain.Entity;
using Pagseguro.Sdk.RecurringPayment.Domain.Interface;
using Pagseguro.Sdk.RecurringPayment.Infra.Helper;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pagseguro.Sdk.RecurringPayment.Application.Service
{
    public class PagseguroPlanService : IPagseguroPlanService
    {
        private readonly IHttpHelper _httpHelper;
        private readonly PagSeguroOptions _options;

        public PagseguroPlanService(IHttpHelper httpHelper,
                           IOptions<PagSeguroOptions> options)
        {
            _httpHelper = httpHelper;
            _options = options.Value;
        }

        public async Task CancelSubscription(string subscriptionCode)
        {
            await _httpHelper.CallApi<string>(new ApiRequest()
            {
                Method = HttpMethod.Put,
                Resource = $"{ApiConstants.PreApprovals}/{subscriptionCode}/{ApiConstants.Cancel}",
                Accept = PagseguroAccept.JsonV3
            });
        }

        public async Task<SubscribeResult> Subscribe(SubscribeRequest subscribeRequest)
        {
            if (_options.SandboxMode)
                subscribeRequest.Sender.Email = _options.SandboxBuyerEmail;

            return await _httpHelper.CallApi<SubscribeResult>(new ApiRequest()
            {
                Method = HttpMethod.Post,
                Accept = PagseguroAccept.JsonV1,
                Body = subscribeRequest.ToBodyPayload(),
                Resource = ApiConstants.PreApprovals,

            });
        }
    }
}

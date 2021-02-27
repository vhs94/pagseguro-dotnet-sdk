using Pagseguro.Sdk.RecurringPayment.Application.Inteface;
using Pagseguro.Sdk.RecurringPayment.Domain.Entity;
using Pagseguro.Sdk.RecurringPayment.Domain.Interface;
using Pagseguro.Sdk.RecurringPayment.Infra.Helper;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pagseguro.Sdk.RecurringPayment.Application.Service
{
    public class PagseguroPaymentMethodService : IPagseguroPaymentMethodService
    {
        private readonly IHttpHelper _httpHelper;

        public PagseguroPaymentMethodService(IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public async Task Update(UpdatePaymentMethodRequest updatePaymentMethodRequest)
        {
            var resource = $"{ApiConstants.PreApprovals}/{updatePaymentMethodRequest.SubscriptionCode}/{ApiConstants.PaymentMethod}";
            await _httpHelper.CallApi<string>(new ApiRequest()
            {
                Method = HttpMethod.Put,
                Resource = resource,
                Body = updatePaymentMethodRequest.PaymentMethod.ToBodyPayload(updatePaymentMethodRequest.SenderHash),
                Accept = PagseguroAccept.JsonV3
            });
        }
    }
}

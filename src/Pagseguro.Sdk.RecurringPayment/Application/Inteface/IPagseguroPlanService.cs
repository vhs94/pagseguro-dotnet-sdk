using Pagseguro.Sdk.RecurringPayment.Domain.Entity;
using System.Threading.Tasks;

namespace Pagseguro.Sdk.RecurringPayment.Application.Inteface
{
    public interface IPagseguroPlanService
    {
        Task<SubscribeResult> Subscribe(SubscribeRequest subscribeRequest);
        Task CancelSubscription(string subscriptionCode);
    }
}

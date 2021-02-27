using Pagseguro.Sdk.RecurringPayment.Domain.Entity;
using System.Threading.Tasks;

namespace Pagseguro.Sdk.RecurringPayment.Application.Inteface
{
    public interface IPagseguroPaymentMethodService
    {
        Task Update(UpdatePaymentMethodRequest updatePaymentMethodRequest);
    }
}

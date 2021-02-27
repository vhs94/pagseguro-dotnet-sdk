using System.Threading.Tasks;

namespace Pagseguro.Sdk.RecurringPayment.Application.Inteface
{
    public interface IPagseguroSessionService
    {
        Task<string> NewSession();
    }
}

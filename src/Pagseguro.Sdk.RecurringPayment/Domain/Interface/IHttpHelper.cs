using Pagseguro.Sdk.RecurringPayment.Domain.Entity;
using System.Threading.Tasks;

namespace Pagseguro.Sdk.RecurringPayment.Domain.Interface
{
    public interface IHttpHelper
    {
        Task<string> CallApi(ApiRequest request);
        Task<TResult> CallApi<TResult>(ApiRequest request);
    }
}

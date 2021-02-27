using System.Net.Http;

namespace Pagseguro.Sdk.RecurringPayment.Domain.Entity
{
    public class ApiRequest
    {
        public HttpMethod Method { get; set; }
        public string Resource { get; set; }
        public PagseguroAccept? Accept { get; set; }
        public object Body { get; set; }
        public bool JsonContent { get; set; } = true;
    }
}

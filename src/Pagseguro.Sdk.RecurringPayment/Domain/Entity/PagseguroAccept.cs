using System.ComponentModel;

namespace Pagseguro.Sdk.RecurringPayment.Domain.Entity
{
    public enum PagseguroAccept
    {
        [Description("application/vnd.pagseguro.com.br.v1+json;charset=ISO-8859-1")]
        JsonV1,

        [Description("application/vnd.pagseguro.com.br.v3+json;charset=ISO-8859-1")]
        JsonV3
    }
}

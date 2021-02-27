namespace Pagseguro.Sdk.RecurringPayment.Domain.Entity
{
    public class PagSeguroOptions
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public bool SandboxMode { get; set; }
        public string SandboxBuyerEmail { get; set; }
    }
}

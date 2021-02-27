namespace Pagseguro.Sdk.RecurringPayment.Domain.Entity
{
    public class PaymentMethod
    {
        public string Token { get; set; }
        public Holder Holder { get; set; }
    }
}

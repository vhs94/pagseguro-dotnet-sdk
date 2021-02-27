namespace Pagseguro.Sdk.RecurringPayment.Domain.Entity
{
    public class UpdatePaymentMethodRequest
    {
        public string SubscriptionCode { get; set; }
        public string SenderHash { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}

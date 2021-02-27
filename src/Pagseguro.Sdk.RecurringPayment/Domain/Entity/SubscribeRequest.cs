namespace Pagseguro.Sdk.RecurringPayment.Domain.Entity
{
    public class SubscribeRequest
    {
        public string PlanCode { get; set; }
        public string Reference { get; set; }
        public Sender Sender { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}

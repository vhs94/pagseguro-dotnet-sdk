namespace Pagseguro.Sdk.RecurringPayment.Domain.Entity
{
    public class Sender
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Cpf { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
    }
}

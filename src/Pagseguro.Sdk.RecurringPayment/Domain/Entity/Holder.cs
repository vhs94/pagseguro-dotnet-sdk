using System;

namespace Pagseguro.Sdk.RecurringPayment.Domain.Entity
{
    public class Holder
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
    }
}

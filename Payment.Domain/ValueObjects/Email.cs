using Flunt.Validations;
using Payment.Shared.ValueObjects;

namespace Payment.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }
        public Email(
            string address
        ) {
            this.Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Email.Address", "Email inválido")
            );
        }
    }
}
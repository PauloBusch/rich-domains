using Flunt.Validations;
using Payment.Shared.ValueObjects;

namespace Payment.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(
            string firstName,
            string lastName
        ) {
            this.FirstName = firstName;
            this.LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Paramter firstName require 3 min chars")
                .HasMinLen(LastName, 3, "Name.LastName", "Paramter lastName require 3 min chars")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Paramter firstName require max 40 chars")
            );
        }
    }
}
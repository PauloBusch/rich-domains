using Flunt.Validations;
using Payment.Domain.Enums;
using Payment.Shared.ValueObjects;

namespace Payment.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        public Document(
            string number,
            EDocumentType type
        ) {
            this.Number = number;
            this.Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Invalid document")
            );
        }

        public bool Validate()
        {
            if (Type == EDocumentType.CNPJ && Number.Length == 14) return true;
            if (Type == EDocumentType.CPF && Number.Length == 11) return true;
            return false;
        }
    }
}
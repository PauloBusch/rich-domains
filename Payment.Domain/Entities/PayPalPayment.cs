
namespace PaymentContext.Domain.Entities {
    public class PayPalPayment : Payment {
        public string TransactionCode { get; private set; }

        public PayPalPayment(
            string transactionCode,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            Document document,
            Address addresss,
            Email email
        ) : base(
            paidDate,
            expireDate,
            total,
            totalPaid,
            payer,
            document,
            addresss,
            email
        ) {
            this.TransactionCode = transactionCode;
        }
    }
}
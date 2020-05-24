
namespace PaymentContext.Domain.Entities {
    public class BoletoPayment : Payment {
        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }

        public BoletoPayment(
            string barCode,
            string boletoNumber,
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
            this.BarCode = barCode;
            this.BoletoNumber = boletoNumber;
        }
    }
}
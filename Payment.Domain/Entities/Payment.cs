
namespace PaymentContext.Domain.Entities {
    public abstract class Payment {
        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public string Document { get; private set; }
        public string Address { get; private set; }
        public string Email { get; private set; }

        public Payment(
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            string document,
            string addresss,
            string email
        ) {
            Number = Guid.NewGuid().ToString().Replace('-', '').Substring(0, 10).ToUpper();
            this.PaidDate = paidDate;
            this.ExpireDate = expireDate;
            this.Total = total;
            this.TotalPaid = totalPaid;
            this.Payer = payer;
            this.Document = document;
            this.Address = address;
            this.Email = email;
        }
    }
}

using Flunt.Validations;
using Payment.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System;

namespace PaymentContext.Domain.Entities {
    public abstract class Payment : Entity {
        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }

        public Payment(
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            Document document,
            Address address,
            Email email
        ) {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            this.PaidDate = paidDate;
            this.ExpireDate = expireDate;
            this.Total = total;
            this.TotalPaid = totalPaid;
            this.Payer = payer;
            this.Document = document;
            this.Address = address;
            this.Email = email;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(0, Total, "Payment.Total", "Parameter total require positive")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "Parameter total is invalid")
            );
        }
    }
}
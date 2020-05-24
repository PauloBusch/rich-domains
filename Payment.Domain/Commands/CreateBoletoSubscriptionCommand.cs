using Flunt.Notifications;
using Flunt.Validations;
using Payment.Domain.Enums;
using Payment.Shared.Commands;
using System;

namespace Payment.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }

        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
        public string PayerNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string PayerEmail { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Paramter firstName require 3 min chars")
                .HasMinLen(LastName, 3, "Name.LastName", "Paramter lastName require 3 min chars")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Paramter firstName require max 40 chars")
            );
        }
    }
}

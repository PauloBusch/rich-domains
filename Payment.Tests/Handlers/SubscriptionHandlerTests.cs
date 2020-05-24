using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Commands;
using Payment.Domain.Enums;
using Payment.Domain.Handlers;
using Payment.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void Test()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand { 
                FirstName = "Paulo",
                LastName = "Busch",
                Document = "32165498745",
                Email = "paulo@teste.com",
                BarCode = "321321321",
                BoletoNumber = "321321321321321",
                PayerNumber = "321321",
                PaidDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddDays(30),
                Total = 321,
                TotalPaid = 321,
                PayerDocument = "321321321",
                PayerDocumentType = EDocumentType.CPF,
                PayerEmail = "teste@email.com",
                Street = "Piên",
                Number = "321321",
                Neighborhood = "Testes",
                City = "Piên",
                State = "PR",
                Country = "Tests",
                ZipCode = "32121"
            };

            handler.Handle(command);
            Assert.IsFalse(handler.Valid);
        }
    }
}

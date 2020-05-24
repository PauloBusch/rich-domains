using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Enums;
using Payment.Domain.ValueObjects;
using PaymentContext.Domain.Entities;
using System;

namespace Payment.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Paulo", "Busch");
            _document = new Document("32165498721", EDocumentType.CPF);
            _email = new Email("paulo@teste.com");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            _address = new Address("Test", "321", "Test", "Pien", "PR", "Test", "321");
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("321321321", DateTime.Now, DateTime.Now.AddDays(5), 0, 0, "test", _document, _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadNoPayment()
        {
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHadNoActiveSubscription()
        {
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}

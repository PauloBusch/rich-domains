using Payment.Domain.Repositories;
using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        { }

        public bool DocumentExists(string document)
        {
            return document == "00000000000";
        }

        public bool EmailExists(string email)
        {
            return email == "balta.io";
        }
    }
}

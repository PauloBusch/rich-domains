using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Enums;
using Payment.Domain.Queries;
using Payment.Domain.ValueObjects;
using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payment.Tests.Queries
{
    [TestClass]
    public class StudantQueriesTests
    {
        private readonly List<Student> _students;
        public StudantQueriesTests()
        {
            for (var i = 0; i < 10; i++){ 
                var student = new Student(
                    name: new Name("Paulo", "Busch"),
                    document: new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                    email: new Email(i.ToString() + "@teste.com")
                );
                _students.Add(student);
            }
        }

        [TestMethod]
        public void ShouldReturnNullWenDocumentNotExists()
        {
            var exp = StudantQueries.GetStudantInfo("212121");
            var studant = _students.AsQueryable().Where(exp);
            Assert.IsNull(studant);
        }

        [TestMethod]
        public void ShouldReturnStudantWenDocumentExists()
        {
            var exp = StudantQueries.GetStudantInfo("11111111111");
            var studant = _students.AsQueryable().Where(exp);
            Assert.IsNotNull(studant);
        }
    }
}

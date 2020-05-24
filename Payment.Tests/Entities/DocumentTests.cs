using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Enums;
using Payment.Domain.ValueObjects;

namespace Payment.Tests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("321", EDocumentType.CPF, false)]
        [DataRow("32132165454", EDocumentType.CPF, true)]
        [DataRow("321", EDocumentType.CNPJ, false)]
        [DataRow("32132165454321", EDocumentType.CNPJ, true)]
        public void ValidateDocument(
            string document,
            EDocumentType type,
            bool valid
        ) {
            var doc = new Document(document, type);
            Assert.Equals(doc.Valid, valid);
        }
    }
}

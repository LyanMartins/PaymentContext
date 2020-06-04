using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObject;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {
        //Red, Green, Refactor
        [TestMethod]
        public void SouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
           
        }
        [TestMethod]
        public void SouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("91515890000120", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }
        [TestMethod]
        public void SouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("1234", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
           
        }
        [TestMethod]
        public void SouldReturnSuccessWhenCPFIsValid()
        {
            //
            var doc = new Document("98532836038", EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
           
        }
    }
}

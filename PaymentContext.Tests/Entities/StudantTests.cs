using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObject;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudantTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenActiveSubscription()
        {
            var name = new Name("bruce","waui");
            var document = new Document("98532836038",EDocumentType.CPF);
            var email = new Email("bruce@waui.com");
            var studant = new Studant(name, document, email);
            Assert.Fail();
        }
        public void ShouldReturnSuccessWhenHadNoActiveSubscription()
        {
            Assert.Fail();
        }
    }
}

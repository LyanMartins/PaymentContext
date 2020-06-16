using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHendleTest
    {
        [TestMethod]
        public void SouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudantRepository());
            var command = new CreateBoletoSubscriptionCommand();

            command.BarCode = "12345678";

            command.FirstName ="Lyan";
            command.LastName ="Martins";
            command.Document ="99999999999";
            command.Email ="email@email2.com";
            command.BarCode ="11111";
            command.BoletoNumber ="11111";
            command.PaymentNumber ="11111";
            command.PaidDate = DateTime.Now;
            command.ExpireDate =DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer ="LYAN CORP";
            command.PayerDocument ="123456748911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "lyan@emai..com";
            command.Street = "qqq";
            command.Number = "sss";
            command.Neighborhood = "asdfçmkadk";
            command.City = "aa";
            command.State = "dddd";
            command.Country = "as";
            command.ZipCode = "12345678";

            handler.Handle(command);
            Assert.AreEqual(false, command);
            
    }
}
using System;
using System.Diagnostics.Contracts;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObject;
using PaymentContext.Shared.Coomands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudantRepository _repository ;

        public SubscriptionHandler(IStudantRepository repository){
            _repository = repository;
        } 
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            if(_repository.DocumentExists(command.Document)){
                AddNotification("Document","Este CPF já está em uso");
            }

            if(_repository.EmailExists(command.Email)){
                AddNotification("Document","Este CPF já está em uso");
            }

            var name =  new Name(command.FirstName,command.LastName);
            var document = new Document(command.Document,EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            var studant = new Studant(name,document,email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, 
                command.BoletoNumber, 
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.PayerDocument,command.PayerDocumentType),
                address,email
            );
            subscription.AddPayment(payment);
            studant.AddSubscription(subscription);

            AddNotifications(name,document,email,address,studant,subscription);

            _repository.CreateSubscription(studant);

            return new CommandResult(true, "Assinatura realizada com sucesso!");

        }
    }
}
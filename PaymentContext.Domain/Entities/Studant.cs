using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObject;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Studant : Entity
    {
        private IList<Subscription> _subscriptions;
        private string v;


        public Studant(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscription { get{ return _subscriptions.ToArray(); }}
        
        public void AddSubscription(Subscription subscription)
        {
            
            var hasSubActive = false;
            foreach (var sub in Subscription)
            {
                if (sub.Active)
                    hasSubActive = true;
            }

            AddNotifications( new Contract()
                .Requires()
                .IsFalse(hasSubActive, "Studant.Subscription","Voce ja tem uma assinatura!")
            );
            // foreach (var sub in Subscription){
            //     sub.SetPaymentActive(false);
            // }

            // _subscriptions.Add(subscription);
        }
    }
}
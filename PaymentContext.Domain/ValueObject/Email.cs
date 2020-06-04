using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObject
{
    public class Email : VObject
    {
        public Email(string address)
        {
            Address = address;
            
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Email.Address", "E-mail Invalido!")
            );
        }

        public string Address { get; private set; }

    }
}
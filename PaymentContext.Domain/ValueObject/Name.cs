using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObject
{
    public class Name : VObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter mais de 3 caracter")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome não pode conter mais de 40 caracter")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter mais de 3 caracter")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
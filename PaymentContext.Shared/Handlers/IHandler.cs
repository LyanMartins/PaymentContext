

using PaymentContext.Shared.Coomands;

namespace PaymentContext.Shared.Handlers
{
    public interface IHandler<T> where T: ICommand
    {
        ICommandResult Handle(T command);
    }
}
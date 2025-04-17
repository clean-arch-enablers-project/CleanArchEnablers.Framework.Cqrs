using CleanArchEnablers.Utils.Cqrs.Abstractions;

namespace CleanArchEnablers.Utils.Cqrs.Dispatchers;

public interface ICommandDispatcher
{
    Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellation)
        where TCommand : ICommand;
}
namespace CleanArchEnablers.Framework.Cqrs.Dispatchers;

public interface ICommandDispatcher
{
    Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellation);
}
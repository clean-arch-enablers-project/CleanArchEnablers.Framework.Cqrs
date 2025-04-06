namespace CleanArchEnablers.Framework.Cqrs.Handlers;

public interface ICommandHandler<in TCommand, TCommandResult>
{
    Task<TCommandResult> Handle(TCommand command, CancellationToken cancellationToken);
}
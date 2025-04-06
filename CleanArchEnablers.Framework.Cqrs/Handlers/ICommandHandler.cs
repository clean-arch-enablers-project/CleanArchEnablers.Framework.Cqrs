using CleanArchEnablers.Framework.Cqrs.Abstractions;

namespace CleanArchEnablers.Framework.Cqrs.Handlers;

public interface ICommandHandler<in TCommand, TCommandResult> where TCommand : ICommand
{
    Task<TCommandResult> Handle(TCommand command, CancellationToken cancellationToken);
}
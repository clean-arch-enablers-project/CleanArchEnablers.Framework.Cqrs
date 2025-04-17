using CleanArchEnablers.Utils.Cqrs.Abstractions;

namespace CleanArchEnablers.Utils.Cqrs.Handlers;

public interface ICommandHandler<in TCommand, TCommandResult> where TCommand : ICommand
{
    Task<TCommandResult> Handle(TCommand command, CancellationToken cancellationToken);
}
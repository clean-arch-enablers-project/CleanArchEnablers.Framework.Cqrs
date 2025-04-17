using CleanArchEnablers.Utils.Cqrs.Abstractions;
using CleanArchEnablers.Utils.Cqrs.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchEnablers.Utils.Cqrs.Dispatchers.Implementations;

public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    public Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellation) where TCommand : ICommand
    {
        var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();
        return handler.Handle(command, cancellation);
    }
}
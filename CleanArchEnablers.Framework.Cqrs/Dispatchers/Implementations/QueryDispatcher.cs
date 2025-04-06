using CleanArchEnablers.Framework.Cqrs.Abstractions;
using CleanArchEnablers.Framework.Cqrs.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchEnablers.Framework.Cqrs.Dispatchers.Implementations;

public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation) where TQuery : IQuery
    {
        var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
        return handler.Handle(query, cancellation);
    }
}
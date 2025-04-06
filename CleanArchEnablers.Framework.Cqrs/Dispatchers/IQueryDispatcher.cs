using CleanArchEnablers.Framework.Cqrs.Abstractions;

namespace CleanArchEnablers.Framework.Cqrs.Dispatchers;

public interface IQueryDispatcher
{
    Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation) where TQuery : IQuery;
}
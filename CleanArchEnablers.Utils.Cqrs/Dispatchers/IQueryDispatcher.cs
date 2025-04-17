using CleanArchEnablers.Utils.Cqrs.Abstractions;

namespace CleanArchEnablers.Utils.Cqrs.Dispatchers;

public interface IQueryDispatcher
{
    Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation) where TQuery : IQuery;
}
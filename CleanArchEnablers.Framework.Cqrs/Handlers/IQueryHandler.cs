using CleanArchEnablers.Framework.Cqrs.Abstractions;

namespace CleanArchEnablers.Framework.Cqrs.Handlers;

public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery
{
    Task<TQueryResult> Handle(TQuery query, CancellationToken cancellationToken);
}
using CleanArchEnablers.Framework.Cqrs.Example.Infrastructure.Repositories;
using CleanArchEnablers.Framework.Cqrs.Handlers;

namespace CleanArchEnablers.Framework.Cqrs.Example.Application.FetchUsers.Handler;

public class FetchUsersQueryHandler(IUserRepository repository) : IQueryHandler<FetchUsersQuery, FetchUsersQueryResult>
{
    public async Task<FetchUsersQueryResult> Handle(FetchUsersQuery query, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var users = await repository.FetchUserAsync(cancellationToken);

        return new FetchUsersQueryResult(users);
    }
}
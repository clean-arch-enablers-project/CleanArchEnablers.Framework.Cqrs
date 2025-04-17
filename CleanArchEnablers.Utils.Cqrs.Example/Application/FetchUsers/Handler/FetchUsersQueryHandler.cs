using CleanArchEnablers.Utils.Cqrs.Example.Infrastructure.Repositories;
using CleanArchEnablers.Utils.Cqrs.Handlers;

namespace CleanArchEnablers.Utils.Cqrs.Example.Application.FetchUsers.Handler;

public class FetchUsersQueryHandler(IUserRepository repository) : IQueryHandler<FetchUsersQuery, FetchUsersQueryResult>
{
    public async Task<FetchUsersQueryResult> Handle(FetchUsersQuery query, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var users = await repository.FetchUserAsync(cancellationToken);

        return new FetchUsersQueryResult(users);
    }
}
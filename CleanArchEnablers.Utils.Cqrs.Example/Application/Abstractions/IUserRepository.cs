using CleanArchEnablers.Utils.Cqrs.Example.Domain.Entities;

namespace CleanArchEnablers.Utils.Cqrs.Example.Infrastructure.Repositories;

public interface IUserRepository
{
    Task<UserDomainEntity> CreateUser(UserDomainEntity entity);
    Task<List<UserDomainEntity>> FetchUserAsync(CancellationToken cancellationToken);
}
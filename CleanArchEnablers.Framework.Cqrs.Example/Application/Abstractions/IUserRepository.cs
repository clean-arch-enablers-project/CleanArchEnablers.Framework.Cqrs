using CleanArchEnablers.Framework.Cqrs.Example.Domain.Entities;

namespace CleanArchEnablers.Framework.Cqrs.Example.Infrastructure.Repositories;

public interface IUserRepository
{
    Task<UserDomainEntity> CreateUser(UserDomainEntity entity);
    Task<List<UserDomainEntity>> FetchUserAsync(CancellationToken cancellationToken);
}
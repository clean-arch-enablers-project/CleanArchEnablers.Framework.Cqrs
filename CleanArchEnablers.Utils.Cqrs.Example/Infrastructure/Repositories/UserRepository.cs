using CleanArchEnablers.Utils.Cqrs.Example.Domain.Entities;
using CleanArchEnablers.Utils.Cqrs.Example.Domain.Entities.Factories;
using CleanArchEnablers.Utils.Cqrs.Example.Infrastructure.Context;
using CleanArchEnablers.Utils.Cqrs.Example.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchEnablers.Utils.Cqrs.Example.Infrastructure.Repositories.Implementation;

public class UserRepository(DatabaseContext context) : IUserRepository
{
    private readonly DatabaseContext _context = context;

    public async Task<UserDomainEntity> CreateUser(UserDomainEntity entity)
    {
        // Mapping DomainEntity to PersistanceEntity
        var user = new UserEntity
        {
            Id = entity.Id,
            Email = entity.Email,
            Password = entity.Password,
            IsBlocked = entity.IsBlocked
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<List<UserDomainEntity>> FetchUserAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await _context.Users
            .Select(u => MapUserToDomainEntity(u))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    private UserDomainEntity MapUserToDomainEntity(UserEntity u)
    {
        return UserDomainEntityFactory.CreateInstance(u.Email, u.Password, u.Id, u.IsBlocked);
    }
}
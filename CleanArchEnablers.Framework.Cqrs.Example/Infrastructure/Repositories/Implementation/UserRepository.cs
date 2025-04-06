using CleanArchEnablers.Framework.Cqrs.Example.Domain.Entities;
using CleanArchEnablers.Framework.Cqrs.Example.Infrastructure.Context;
using CleanArchEnablers.Framework.Cqrs.Example.Infrastructure.Entities;

namespace CleanArchEnablers.Framework.Cqrs.Example.Infrastructure.Repositories.Implementation;

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
}
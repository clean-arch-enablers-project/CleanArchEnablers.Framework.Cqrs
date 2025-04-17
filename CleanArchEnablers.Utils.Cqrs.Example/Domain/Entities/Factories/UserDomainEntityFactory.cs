using CleanArchEnablers.Utils.Cqrs.Example.Domain.Entities.Implementation;

namespace CleanArchEnablers.Utils.Cqrs.Example.Domain.Entities.Factories;

public static class UserDomainEntityFactory
{
    public static UserDomainEntity CreateInstance(string email, string password, Guid? id = null, bool? isBlocked = null)
    {
        return new UserDomainEntityImplementation(email, password, id, isBlocked);
    }
}
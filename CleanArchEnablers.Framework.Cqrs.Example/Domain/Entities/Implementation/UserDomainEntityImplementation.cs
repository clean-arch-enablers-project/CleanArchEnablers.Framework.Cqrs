namespace CleanArchEnablers.Framework.Cqrs.Example.Domain.Entities.Implementation;

public class UserDomainEntityImplementation : UserDomainEntity
{
    public UserDomainEntityImplementation(string email, string password, Guid? id = null, bool? isBlocked = null)
    {
        Email = email;
        Password = password;
        Id = id ?? Guid.NewGuid();
        IsBlocked = isBlocked ?? false;
    }
        
    public override void ActivateUser()
    {
        if (IsBlocked is false) return;

        IsBlocked = false;
    }

    public override void BlockUser()
    {
        if (IsBlocked) return;
        
        IsBlocked = true;
    }
}
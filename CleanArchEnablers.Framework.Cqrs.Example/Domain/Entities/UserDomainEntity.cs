namespace CleanArchEnablers.Framework.Cqrs.Example.Domain.Entities;

public abstract class UserDomainEntity
{
    public Guid Id { get; protected set; }
    public string Email { get; protected set; } = string.Empty;
    public string Password { get; protected set; } = string.Empty;
    public bool IsBlocked { get; protected set; }

    public abstract void ActivateUser();
    public abstract void BlockUser();
}
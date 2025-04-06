using CleanArchEnablers.Framework.Cqrs.Example.Domain.Entities;

namespace CleanArchEnablers.Framework.Cqrs.Example.Application.CreateUser;

public record CreateUserCommandResult(UserDomainEntity user);
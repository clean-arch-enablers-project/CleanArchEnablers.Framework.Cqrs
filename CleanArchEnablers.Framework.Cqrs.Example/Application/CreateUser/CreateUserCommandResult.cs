using CleanArchEnablers.Framework.Cqrs.Example.Domain.Entities;

namespace CleanArchEnablers.Framework.Cqrs.Example.Application.CreateUser.IO;

public record CreateUserCommandResult(UserDomainEntity user);
using CleanArchEnablers.Utils.Cqrs.Example.Domain.Entities;

namespace CleanArchEnablers.Utils.Cqrs.Example.Application.CreateUser;

public record CreateUserCommandResult(UserDomainEntity user);
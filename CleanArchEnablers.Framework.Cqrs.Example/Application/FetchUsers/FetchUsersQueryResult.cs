using CleanArchEnablers.Framework.Cqrs.Example.Domain.Entities;

namespace CleanArchEnablers.Framework.Cqrs.Example.Application.FetchUsers;

public record FetchUsersQueryResult(List<UserDomainEntity> Users);
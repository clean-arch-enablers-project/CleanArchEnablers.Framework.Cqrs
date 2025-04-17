using CleanArchEnablers.Utils.Cqrs.Example.Domain.Entities;

namespace CleanArchEnablers.Utils.Cqrs.Example.Application.FetchUsers;

public record FetchUsersQueryResult(List<UserDomainEntity> Users);
using CleanArchEnablers.Framework.Cqrs.Example.Domain.Entities.Factories;
using CleanArchEnablers.Framework.Cqrs.Example.Infrastructure.Repositories;
using CleanArchEnablers.Framework.Cqrs.Handlers;

namespace CleanArchEnablers.Framework.Cqrs.Example.Application.CreateUser.Handler;

public class CreateUserCommandHandler(IUserRepository repository)
    : ICommandHandler<CreateUserCommand, CreateUserCommandResult>
{
    private readonly IUserRepository _repository = repository;

    public async Task<CreateUserCommandResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = UserDomainEntityFactory.CreateInstance(command.Email, command.Password);
        var result = await _repository.CreateUser(user);

        return new CreateUserCommandResult(result);
    }
}
using CleanArchEnablers.Framework.Cqrs.Abstractions;

namespace CleanArchEnablers.Framework.Cqrs.Example.Application.CreateUser;

public record CreateUserCommand(
    string Email, 
    string Password) : ICommand;
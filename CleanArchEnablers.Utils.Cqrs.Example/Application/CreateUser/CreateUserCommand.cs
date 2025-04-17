using CleanArchEnablers.Utils.Cqrs.Abstractions;

namespace CleanArchEnablers.Utils.Cqrs.Example.Application.CreateUser;

public record CreateUserCommand(
    string Email, 
    string Password) : ICommand;
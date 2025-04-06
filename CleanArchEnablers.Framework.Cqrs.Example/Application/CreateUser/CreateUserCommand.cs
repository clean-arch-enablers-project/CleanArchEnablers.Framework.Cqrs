using CleanArchEnablers.Framework.Cqrs.Abstractions;

namespace CleanArchEnablers.Framework.Cqrs.Example.Application.CreateUser.IO;

public record CreateUserCommand(
    string Email, 
    string Password) : ICommand;
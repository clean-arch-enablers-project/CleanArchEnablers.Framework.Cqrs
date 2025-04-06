using CleanArchEnablers.Framework.Cqrs.Dispatchers;
using CleanArchEnablers.Framework.Cqrs.Example.Application.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchEnablers.Framework.Cqrs.Example.Controllers;

[ApiController]
[Route("/api/")]
public class UserController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public UserController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost("v1/user")]
    public async Task<IActionResult> CreateUser(CreateUserCommand command, CancellationToken cancellationToken)
    {
        // Here you will send a message to dispatcher
        var user = await _commandDispatcher.Dispatch<CreateUserCommand, CreateUserCommandResult>(command, cancellationToken);
        
        var response = new
        {
            Type = user.GetType().ToString(),
            User = user
        };
        return Ok(response);
    }
}
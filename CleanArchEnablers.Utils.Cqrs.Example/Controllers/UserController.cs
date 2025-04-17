using CleanArchEnablers.Utils.Cqrs.Dispatchers;
using CleanArchEnablers.Utils.Cqrs.Example.Application.CreateUser;
using CleanArchEnablers.Utils.Cqrs.Example.Application.FetchUsers;
using CleanArchEnablers.Utils.Cqrs.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchEnablers.Utils.Cqrs.Example.Controllers;

[ApiController]
[Route("/api/")]
public class UserController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher = queryDispatcher;

    [HttpPost("v1/user")]
    public async Task<IActionResult> CreateUser(CreateUserCommand command, CancellationToken cancellationToken)
    {
        // Here you will send a message to dispatcher
        var user = await commandDispatcher.Dispatch<CreateUserCommand, CreateUserCommandResult>(command, cancellationToken);
        
        var response = new
        {
            Type = user.GetType().ToString(),
            User = user.user
        };
        return Ok(response);
    }

    [HttpGet("v1/user")]
    public async Task<IActionResult> FetchUsers(CancellationToken cancellationToken)
    {
        var query = new FetchUsersQuery();
        var users = await _queryDispatcher.Dispatch<FetchUsersQuery, FetchUsersQueryResult>(query, cancellationToken);

        if (users.Users.Count == 0) return NotFound();
        
        var response = new
        {
            Type = users.Users.GetType().ToString(),
            Users = users.Users
        };
        return Ok(response);
    }
}
using Microsoft.AspNetCore.Mvc;
using MimirCore.Api.Models.User;
using MimirCore.Application.CQRS.Normal.Queries.User;
using MimirCore.Application.CQRS.Normal.Commands.User;

namespace MimirCore.Api.Controllers.Public;

[Route("api/auth")]
public class AuthController : BaseApiController
{
    [HttpPost("login")]
    public async Task<ActionResult<UserResponse>> Login([FromBody] LoginRequest request)
    {
        var query = new GetUserByEmailQuery(request.Email);
        var result = await Mediator.Send(query);
        return HandleResult(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserResponse>> Register([FromBody] CreateUserRequest request)
    {
        var command = new CreateUserCommand
        {
            Username = request.Username,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }

    [HttpPost("change-password")]
    public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var userId = GetCurrentUserId();
        var command = new ChangePasswordCommand
        {
            UserId = userId,
            CurrentPassword = request.CurrentPassword,
            NewPassword = request.NewPassword
        };

        await Mediator.Send(command);
        return Ok();
    }
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class ChangePasswordRequest
{
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}
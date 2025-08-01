using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MimirCore.Api.Models.User;
using MimirCore.Application.CQRS.Normal.Commands.User;
using MimirCore.Application.CQRS.Normal.Queries.User;

namespace MimirCore.Api.Controllers.Public;

[Authorize]
[Route("api/profile")]
public class UserController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<UserResponse>> GetProfile()
    {
        var userId = GetCurrentUserId();
        var query = new GetUserByIdQuery(userId);
        var result = await Mediator.Send(query);
        return HandleResult(result);
    }

    [HttpPut]
    public async Task<ActionResult<UserResponse>> UpdateProfile([FromBody] UpdateUserRequest request)
    {
        var userId = GetCurrentUserId();
        var command = new UpdateUserCommand
        {
            Id = userId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }
}
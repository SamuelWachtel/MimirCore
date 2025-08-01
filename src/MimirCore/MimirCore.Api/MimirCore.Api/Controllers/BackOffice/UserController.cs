using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MimirCore.Api.Models.User;
using MimirCore.Application.CQRS.BackOffice.Commands.User;
using MimirCore.Application.CQRS.BackOffice.Queries.User;

namespace MimirCore.Api.Controllers.BackOffice;

[Authorize(Roles = "Admin,BackOffice")]
[Route("api/backoffice/users")]
public class UserController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<UserPaginatedListResponse>> GetAllUsers(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? searchTerm = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] string? sortBy = null,
        [FromQuery] string? sortOrder = null)
    {
        var query = new GetAllUsersQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SearchTerm = searchTerm,
            IsActive = isActive,
            SortBy = sortBy ?? "CreatedAt",
            SortOrder = sortOrder ?? "desc"
        };

        var result = await Mediator.Send(query);
        return HandlePaginatedResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetUserById(int id)
    {
        var query = new GetUserByIdQuery(id);
        var result = await Mediator.Send(query);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> CreateUser([FromBody] CreateUserRequest request)
    {
        var command = new CreateUserCommand
        {
            Username = request.Username,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            IsActive = request.IsActive,
            RoleIds = request.RoleIds ?? new List<int>()
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserResponse>> UpdateUser(int id, [FromBody] UpdateUserRequest request)
    {
        var command = new UpdateUserCommand
        {
            Id = id,
            Username = request.Username,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            IsActive = request.IsActive,
            RoleIds = request.RoleIds ?? new List<int>()
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var command = new DeleteUserCommand(id);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{id}/reset-password")]
    public async Task<ActionResult> ResetPassword(int id, [FromBody] ResetPasswordRequest request)
    {
        var command = new ResetPasswordCommand
        {
            UserId = id,
            NewPassword = request.NewPassword,
            RequirePasswordChange = request.RequirePasswordChange
        };

        await Mediator.Send(command);
        return Ok();
    }
}

public class ResetPasswordRequest
{
    public string NewPassword { get; set; } = string.Empty;
    public bool RequirePasswordChange { get; set; } = true;
}
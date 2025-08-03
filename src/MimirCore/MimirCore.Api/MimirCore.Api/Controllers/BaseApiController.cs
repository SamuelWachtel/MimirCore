using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MimirCore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected ActionResult HandleResult<T>(T result)
    {
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    protected ActionResult HandleResult<T>(T result, string message)
    {
        if (result == null)
            return NotFound(message);

        return Ok(result);
    }

    protected Guid GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst("UserId")?.Value;
        if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
        {
            throw new UnauthorizedAccessException("User ID not found in token");
        }
        return userId;
    }

    protected bool IsInRole(string role)
    {
        return User.IsInRole(role);
    }

    protected ActionResult HandlePaginatedResult<T>(T result) where T : class
    {
        if (result == null)
            return NotFound();

        return Ok(result);
    }
}
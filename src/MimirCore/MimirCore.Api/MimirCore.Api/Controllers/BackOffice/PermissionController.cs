using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MimirCore.Api.Models.Permission;
using MimirCore.Application.CQRS.BackOffice.Commands.Permission;
using MimirCore.Application.CQRS.BackOffice.Queries.Permission;

namespace MimirCore.Api.Controllers.BackOffice;

[Authorize(Roles = "Admin,BackOffice")]
[Route("api/backoffice/permissions")]
public class PermissionController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PermissionPaginatedListResponse>> GetAllPermissions(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? category = null,
        [FromQuery] string? searchTerm = null,
        [FromQuery] string? sortBy = null,
        [FromQuery] string? sortOrder = null)
    {
        var query = new GetAllPermissionsQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            Category = category,
            SearchTerm = searchTerm,
            SortBy = sortBy ?? "Category",
            SortOrder = sortOrder ?? "asc"
        };

        var result = await Mediator.Send(query);
        return HandlePaginatedResult(result);
    }

    [HttpPost]
    public async Task<ActionResult<PermissionResponse>> CreatePermission([FromBody] CreatePermissionRequest request)
    {
        var command = new CreatePermissionCommand
        {
            Name = request.Name,
            Description = request.Description,
            Category = request.Category
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }
}

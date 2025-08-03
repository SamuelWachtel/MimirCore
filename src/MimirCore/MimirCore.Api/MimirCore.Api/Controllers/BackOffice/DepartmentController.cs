using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MimirCore.Api.Models.Department;
using MimirCore.Application.CQRS.BackOffice.Commands.Department;
using MimirCore.Application.CQRS.BackOffice.Queries.Department;

namespace MimirCore.Api.Controllers.BackOffice;

[Authorize(Roles = "Admin,HR,BackOffice")]
[Route("api/backoffice/departments")]
public class DepartmentController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<DepartmentPaginatedListResponse>> GetAllDepartments(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? searchTerm = null,
        [FromQuery] int? parentDepartmentId = null,
        [FromQuery] string? sortBy = null,
        [FromQuery] string? sortOrder = null)
    {
        var query = new GetAllDepartmentsQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SearchTerm = searchTerm,
            ParentDepartmentId = parentDepartmentId,
            SortBy = sortBy ?? "Name",
            SortOrder = sortOrder ?? "asc"
        };

        var result = await Mediator.Send(query);
        return HandlePaginatedResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentResponse>> GetDepartmentById(Guid id)
    {
        var query = new GetDepartmentByIdQuery{Id = id};
        var result = await Mediator.Send(query);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateDepartment([FromBody] CreateDepartmentRequest request)
    {
        var command = new CreateDepartmentCommand
        {
            Name = request.Name,
            Description = request.Description,
            ChiefId = request.ChiefId,
            ParentDepartmentId = request.ParentDepartmentId
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<DepartmentResponse>> UpdateDepartment(int id, [FromBody] UpdateDepartmentRequest request)
    {
        var command = new UpdateDepartmentCommand
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            ChiefId = request.ChiefId,
            ParentDepartmentId = request.ParentDepartmentId
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDepartment(int id)
    {
        var command = new DeleteDepartmentCommand(id);
        await Mediator.Send(command);
        return NoContent();
    }
}
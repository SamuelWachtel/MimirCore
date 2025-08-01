using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MimirCore.Api.Models.Employee;
using MimirCore.Application.CQRS.BackOffice.Commands.Employee;
using MimirCore.Application.CQRS.BackOffice.Queries.Employee;

namespace MimirCore.Api.Controllers.BackOffice;

[Authorize(Roles = "Admin,HR,BackOffice")]
[Route("api/backoffice/employees")]
public class EmployeeController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<EmployeePaginatedListResponse>> GetAllEmployees(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? searchTerm = null,
        [FromQuery] string? status = null,
        [FromQuery] int? teamId = null,
        [FromQuery] int? positionId = null,
        [FromQuery] string? sortBy = null,
        [FromQuery] string? sortOrder = null)
    {
        var query = new GetAllEmployeesQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SearchTerm = searchTerm,
            Status = status,
            TeamId = teamId,
            PositionId = positionId,
            SortBy = sortBy ?? "CreatedAt",
            SortOrder = sortOrder ?? "desc"
        };

        var result = await Mediator.Send(query);
        return HandlePaginatedResult(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateEmployee([FromBody] CreateEmployeeRequest request)
    {
        var command = new CreateEmployeeCommand
        {
            EmployeeNumber = request.EmployeeNumber,
            UserId = request.UserId,
            TeamId = request.TeamId,
            PositionId = request.PositionId,
            HireDate = request.HireDate,
            Salary = request.Salary,
            EmploymentType = request.EmploymentType,
            Status = request.Status
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EmployeeResponse>> UpdateEmployee(int id, [FromBody] UpdateEmployeeRequest request)
    {
        var command = new UpdateEmployeeCommand
        {
            Id = id,
            TeamId = request.TeamId,
            PositionId = request.PositionId,
            Salary = request.Salary,
            EmploymentType = request.EmploymentType,
            Status = request.Status,
            TerminationDate = request.TerminationDate
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }

    [HttpPost("{id}/terminate")]
    public async Task<ActionResult> TerminateEmployee(int id, [FromBody] TerminateEmployeeRequest request)
    {
        var command = new UpdateEmployeeCommand
        {
            Id = id,
            TerminationDate = request.TerminationDate
        };

        await Mediator.Send(command);
        return Ok();
    }
}

public class TerminateEmployeeRequest
{
    public DateTime TerminationDate { get; set; }
    public string Reason { get; set; } = string.Empty;
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MimirCore.Api.Controllers.Public;
using MimirCore.Application.CQRS.BackOffice.Commands.Shift;
using MimirCore.Application.CQRS.BackOffice.Queries.Shift;

namespace MimirCore.Api.Controllers.BackOffice;

[Authorize(Roles = "Admin,HR,Manager,BackOffice")]
[Route("api/backoffice/shifts")]
public class ShiftController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<ShiftPaginatedListResponse>> GetAllShifts(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] Guid? employeeId = null,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] string? status = null,
        [FromQuery] string? sortBy = null,
        [FromQuery] string? sortOrder = null)
    {
        var query = new GetAllShiftsQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            EmployeeId = employeeId,
            StartDate = startDate,
            EndDate = endDate,
            Status = status,
            SortBy = sortBy ?? "StartTime",
            SortOrder = sortOrder ?? "desc"
        };

        var result = await Mediator.Send(query);
        return HandlePaginatedResult(result);
    }

    [HttpPost]
    public async Task<ActionResult<ShiftResponse>> CreateShift([FromBody] CreateShiftRequest request)
    {
        var command = new CreateShiftCommand
        {
            EmployeeId = request.EmployeeId,
            ShiftTemplateId = request.ShiftTemplateId,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            Notes = request.Notes
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }
}

public class CreateShiftRequest
{
    public Guid EmployeeId { get; set; }
    public Guid? ShiftTemplateId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Notes { get; set; }
}

public class ShiftResponse
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public Guid? ShiftTemplateId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime? ActualStartTime { get; set; }
    public DateTime? ActualEndTime { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
}
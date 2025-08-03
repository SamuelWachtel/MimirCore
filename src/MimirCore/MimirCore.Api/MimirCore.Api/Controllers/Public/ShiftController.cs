using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MimirCore.Application.CQRS.Normal.Commands.Shift;
using MimirCore.Application.CQRS.Normal.Queries.Shift;

namespace MimirCore.Api.Controllers.Public;

[Authorize]
[Route("api/shifts")]
public class ShiftController : BaseApiController
{
    [HttpGet("my-shifts")]
    public async Task<ActionResult<ShiftPaginatedListResponse>> GetMyShifts(
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var employeeId = GetCurrentUserId();
        var query = new GetMyShiftsQuery
        {
            EmployeeId = employeeId,
            StartDate = startDate,
            EndDate = endDate,
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var result = await Mediator.Send(query);
        return HandlePaginatedResult(result);
    }

    [HttpPost("{shiftId}/check-in")]
    public async Task<ActionResult> CheckIn(Guid shiftId, [FromBody] CheckInRequest request)
    {
        var employeeId = GetCurrentUserId();
        var command = new CheckInCommand
        {
            ShiftId = shiftId,
            EmployeeId = employeeId,
            CheckInTime = request.CheckInTime ?? DateTime.UtcNow,
            Notes = request.Notes
        };

        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("{shiftId}/check-out")]
    public async Task<ActionResult> CheckOut(Guid shiftId, [FromBody] CheckOutRequest request)
    {
        var employeeId = GetCurrentUserId();
        var command = new CheckOutCommand
        {
            ShiftId = shiftId,
            EmployeeId = employeeId,
            CheckOutTime = request.CheckOutTime ?? DateTime.UtcNow,
            Notes = request.Notes
        };

        await Mediator.Send(command);
        return Ok();
    }
}

public class CheckInRequest
{
    public DateTime? CheckInTime { get; set; }
    public string? Notes { get; set; }
}

public class CheckOutRequest
{
    public DateTime? CheckOutTime { get; set; }
    public string? Notes { get; set; }
}

public class ShiftPaginatedListResponse
{
    public IEnumerable<ShiftItemListDto> Items { get; set; } = new List<ShiftItemListDto>();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

public class ShiftItemListDto
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime? ActualStartTime { get; set; }
    public DateTime? ActualEndTime { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Notes { get; set; }
}
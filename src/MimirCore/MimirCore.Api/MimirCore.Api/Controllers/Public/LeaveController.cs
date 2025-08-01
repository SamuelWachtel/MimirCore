using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MimirCore.Application.CQRS.Normal.Commands.Leave;
using MimirCore.Application.CQRS.Normal.Queries.Leave;

namespace MimirCore.Api.Controllers.Public;

[Authorize]
[Route("api/leave")]
public class LeaveController : BaseApiController
{
    [HttpGet("my-requests")]
    public async Task<ActionResult<LeaveRequestPaginatedListResponse>> GetMyLeaveRequests(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? status = null)
    {
        var employeeId = GetCurrentUserId(); // Assuming user has employee context
        var query = new GetMyLeaveRequestsQuery
        {
            EmployeeId = employeeId,
            PageNumber = pageNumber,
            PageSize = pageSize,
            Status = status
        };

        var result = await Mediator.Send(query);
        return HandlePaginatedResult(result);
    }

    [HttpGet("types")]
    public async Task<ActionResult<IEnumerable<LeaveTypeItemListDto>>> GetAvailableLeaveTypes()
    {
        var query = new GetAvailableLeaveTypesQuery();
        var result = await Mediator.Send(query);
        return HandleResult(result);
    }

    [HttpPost("request")]
    public async Task<ActionResult<LeaveRequestResponse>> CreateLeaveRequest([FromBody] CreateLeaveRequestRequest request)
    {
        var employeeId = GetCurrentUserId(); // Assuming user has employee context
        var command = new CreateLeaveRequestCommand
        {
            EmployeeId = employeeId,
            LeaveTypeId = request.LeaveTypeId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Reason = request.Reason
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }

    [HttpPost("{id}/cancel")]
    public async Task<ActionResult> CancelLeaveRequest(int id)
    {
        var employeeId = GetCurrentUserId(); // Assuming user has employee context
        var command = new CancelLeaveRequestCommand
        {
            LeaveRequestId = id,
            EmployeeId = employeeId
        };

        await Mediator.Send(command);
        return Ok();
    }
}

public class CreateLeaveRequestRequest
{
    public int LeaveTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public class LeaveRequestResponse
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class LeaveRequestPaginatedListResponse
{
    public IEnumerable<LeaveRequestItemListDto> Items { get; set; } = new List<LeaveRequestItemListDto>();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

public class LeaveRequestItemListDto
{
    public int Id { get; set; }
    public string LeaveTypeName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DaysRequested { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class LeaveTypeItemListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
    public bool RequiresApproval { get; set; }
}
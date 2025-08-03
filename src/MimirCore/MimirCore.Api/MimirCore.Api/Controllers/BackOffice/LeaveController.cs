using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MimirCore.Api.Controllers.Public;
using MimirCore.Application.CQRS.BackOffice.Commands.Leave;
using MimirCore.Application.CQRS.BackOffice.Queries.Leave;

namespace MimirCore.Api.Controllers.BackOffice;

[Authorize(Roles = "Admin,HR,Manager,BackOffice")]
[Route("api/backoffice/leave")]
public class LeaveController : BaseApiController
{
    [HttpGet("requests")]
    public async Task<ActionResult<LeaveRequestPaginatedListResponse>> GetAllLeaveRequests(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? status = null,
        [FromQuery] int? employeeId = null,
        [FromQuery] int? leaveTypeId = null,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] string? sortBy = null,
        [FromQuery] string? sortOrder = null)
    {
        var query = new GetAllLeaveRequestsQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            Status = status,
            EmployeeId = employeeId,
            LeaveTypeId = leaveTypeId,
            StartDate = startDate,
            EndDate = endDate,
            SortBy = sortBy ?? "CreatedAt",
            SortOrder = sortOrder ?? "desc"
        };

        var result = await Mediator.Send(query);
        return HandlePaginatedResult(result);
    }

    [HttpPost("requests/{id}/approve")]
    public async Task<ActionResult> ApproveLeaveRequest(Guid id, [FromBody] ApproveLeaveRequestRequest request)
    {
        var approvedById = GetCurrentUserId();
        var command = new ApproveLeaveRequestCommand
        {
            LeaveRequestId = id,
            ApprovedById = approvedById,
            Comments = request.Comments
        };

        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("requests/{id}/reject")]
    public async Task<ActionResult> RejectLeaveRequest(Guid id, [FromBody] RejectLeaveRequestRequest request)
    {
        var rejectedById = GetCurrentUserId();
        var command = new RejectLeaveRequestCommand
        {
            LeaveRequestId = id,
            RejectedById = rejectedById,
            Reason = request.Reason
        };

        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("types")]
    public async Task<ActionResult<LeaveTypeResponse>> CreateLeaveType([FromBody] CreateLeaveTypeRequest request)
    {
        var command = new CreateLeaveTypeCommand
        {
            Name = request.Name,
            Description = request.Description,
            DefaultDays = request.DefaultDays,
            RequiresApproval = request.RequiresApproval
        };

        var result = await Mediator.Send(command);
        return HandleResult(result);
    }
}

public class ApproveLeaveRequestRequest
{
    public string? Comments { get; set; }
}

public class RejectLeaveRequestRequest
{
    public string Reason { get; set; } = string.Empty;
}

public class CreateLeaveTypeRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
    public bool RequiresApproval { get; set; } = true;
}

public class LeaveTypeResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
    public bool RequiresApproval { get; set; }
}
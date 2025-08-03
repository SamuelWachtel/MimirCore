using MimirCore.Application.Models.Leave;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class LeaveRequestExtensions
{
    public static LeaveRequestDto ToApplicationDto(this LeaveRequest leaveRequest)
    {
        return new LeaveRequestDto
        {
            Id = leaveRequest.Id,
            EmployeeId = leaveRequest.EmployeeId,
            LeaveTypeId = leaveRequest.LeaveTypeId,
            StartDate = leaveRequest.StartDate,
            EndDate = leaveRequest.EndDate,
            DaysRequested = leaveRequest.TotalDays,
            Reason = leaveRequest.Reason,
            Status = leaveRequest.Status,
            ApprovedById = leaveRequest.ApprovedBy,
            ApprovedAt = leaveRequest.ApprovedAt,
            Comments = leaveRequest.ApprovalComments,
            CreatedAt = leaveRequest.CreatedAt,
            UpdatedAt = leaveRequest.ModifiedAt,
            Employee = leaveRequest.Employee?.ToItemListDto(),
            LeaveType = leaveRequest.LeaveType?.ToItemListDto(),
            ApprovedBy = leaveRequest.Approver?.ToItemListDto()
        };
    }

    public static LeaveRequestItemListDto ToItemListDto(this LeaveRequest leaveRequest)
    {
        return new LeaveRequestItemListDto
        {
            Id = leaveRequest.Id,
            EmployeeName = leaveRequest.Employee != null ? $"{leaveRequest.Employee.User?.FirstName} {leaveRequest.Employee.User?.LastName}" : "",
            LeaveTypeName = leaveRequest.LeaveType?.Name ?? "",
            StartDate = leaveRequest.StartDate,
            EndDate = leaveRequest.EndDate,
            DaysRequested = leaveRequest.TotalDays,
            CreatedAt = leaveRequest.CreatedAt,
            Status = leaveRequest.Status,
        };
    }

    public static LeaveRequest ToEntity(this CreateLeaveRequestDto createLeaveRequestDto)
    {
        return new LeaveRequest
        {
            EmployeeId = createLeaveRequestDto.EmployeeId,
            LeaveTypeId = createLeaveRequestDto.LeaveTypeId,
            StartDate = createLeaveRequestDto.StartDate,
            EndDate = createLeaveRequestDto.EndDate,
            TotalDays = (int)(createLeaveRequestDto.EndDate - createLeaveRequestDto.StartDate).TotalDays + 1,
            Reason = createLeaveRequestDto.Reason,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateLeaveRequestDto updateLeaveRequestDto, LeaveRequest leaveRequest)
    {
        leaveRequest.StartDate = updateLeaveRequestDto.StartDate;
        leaveRequest.EndDate = updateLeaveRequestDto.EndDate;
        leaveRequest.TotalDays = (int)(updateLeaveRequestDto.EndDate - updateLeaveRequestDto.StartDate).TotalDays + 1;
        leaveRequest.Reason = updateLeaveRequestDto.Reason;
        leaveRequest.Status = updateLeaveRequestDto.Status;
        leaveRequest.ApprovalComments = updateLeaveRequestDto.Comments;
        leaveRequest.ModifiedAt = DateTime.UtcNow;
    }

    public static IEnumerable<LeaveRequestDto> ToApplicationDtos(this IEnumerable<LeaveRequest> leaveRequests)
    {
        return leaveRequests.Select(lr => lr.ToApplicationDto());
    }

    public static IEnumerable<LeaveRequestItemListDto> ToItemListDtos(this IEnumerable<LeaveRequest> leaveRequests)
    {
        return leaveRequests.Select(lr => lr.ToItemListDto());
    }
}
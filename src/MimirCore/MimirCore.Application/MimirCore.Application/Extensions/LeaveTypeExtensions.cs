using MimirCore.Application.Models.Leave;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class LeaveTypeExtensions
{
    // Domain -> Application
    public static LeaveTypeDto ToApplicationDto(this LeaveType leaveType)
    {
        return new LeaveTypeDto
        {
            Id = leaveType.Id,
            Name = leaveType.Name,
            Description = leaveType.Description,
            DefaultDays = leaveType.MaxDaysPerYear,
            RequiresApproval = leaveType.RequiresApproval,
            CreatedAt = leaveType.CreatedAt,
            UpdatedAt = leaveType.ModifiedAt
        };
    }

    public static LeaveTypeItemListDto ToItemListDto(this LeaveType leaveType)
    {
        return new LeaveTypeItemListDto
        {
            Id = leaveType.Id,
            Name = leaveType.Name,
            DefaultDays = leaveType.MaxDaysPerYear,
            RequiresApproval = leaveType.RequiresApproval
        };
    }

    // Collection extensions
    public static IEnumerable<LeaveTypeDto> ToApplicationDtos(this IEnumerable<LeaveType> leaveTypes)
    {
        return leaveTypes.Select(lt => lt.ToApplicationDto());
    }

    public static IEnumerable<LeaveTypeItemListDto> ToItemListDtos(this IEnumerable<LeaveType> leaveTypes)
    {
        return leaveTypes.Select(lt => lt.ToItemListDto());
    }
}
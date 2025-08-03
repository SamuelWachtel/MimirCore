using MimirCore.Application.Models;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class ShiftStatusExtensions
{
    public static ShiftStatusDto ToApplicationDto(this ShiftStatus shiftStatus)
    {
        return shiftStatus switch
        {
            ShiftStatus.Scheduled => ShiftStatusDto.Scheduled,
            ShiftStatus.Cancelled => ShiftStatusDto.Cancelled,
            _ => throw new ArgumentOutOfRangeException(nameof(shiftStatus), shiftStatus, null)
        };
    }

    public static ShiftStatus ToEntity(this ShiftStatusDto shiftStatusDto)
    {
        return shiftStatusDto switch
        {
            ShiftStatusDto.Scheduled => ShiftStatus.Scheduled,
            ShiftStatusDto.Cancelled => ShiftStatus.Cancelled,
            _ => throw new ArgumentOutOfRangeException(nameof(shiftStatusDto), shiftStatusDto, null)
        };
    }
    
    public static IEnumerable<ShiftStatusDto> ToApplicationDtos(this IEnumerable<ShiftStatus> priorities)
    {
        return priorities.Select(d => d.ToApplicationDto());
    }

    public static IEnumerable<ShiftStatus> ToDomainEntities(this IEnumerable<ShiftStatusDto> priorities)
    {
        return priorities.Select(d => d.ToEntity());
    }
}
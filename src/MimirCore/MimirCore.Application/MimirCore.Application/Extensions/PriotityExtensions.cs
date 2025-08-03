using MimirCore.Application.Models;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class PriotityExtensions
{
    public static PriorityDto ToApplicationDto(this Priority priority)
    {
        return priority switch
        {
            Priority.Low => PriorityDto.Low,
            Priority.Medium => PriorityDto.Medium,
            Priority.High => PriorityDto.High,
            Priority.Critical => PriorityDto.Critical,
            _ => throw new ArgumentOutOfRangeException(nameof(priority), priority, null)
        };
    }

    public static Priority ToEntity(this PriorityDto priorityDto)
    {
        return priorityDto switch
        {
            PriorityDto.Low => Priority.Low,
            PriorityDto.Medium => Priority.Medium,
            PriorityDto.High => Priority.High,
            PriorityDto.Critical => Priority.Critical,
            _ => throw new ArgumentOutOfRangeException(nameof(priorityDto), priorityDto, null)
        };
    }
    
    public static IEnumerable<PriorityDto> ToApplicationDtos(this IEnumerable<Priority> priorities)
    {
        return priorities.Select(d => d.ToApplicationDto());
    }

    public static IEnumerable<Priority> ToDomainEntities(this IEnumerable<PriorityDto> priorities)
    {
        return priorities.Select(d => d.ToEntity());
    }
}
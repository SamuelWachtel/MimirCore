namespace MimirCore.Api.Extensions;

public static class PriotityExtensions
{
    public static MimirCore.Application.Models.PriorityDto ToApplicationDto(this MimirCore.Api.Models.PriorityDto priority)
    {
        return priority switch
        {
            MimirCore.Api.Models.PriorityDto.Low => MimirCore.Application.Models.PriorityDto.Low,
            MimirCore.Api.Models.PriorityDto.Medium => MimirCore.Application.Models.PriorityDto.Medium,
            MimirCore.Api.Models.PriorityDto.High => MimirCore.Application.Models.PriorityDto.High,
            MimirCore.Api.Models.PriorityDto.Critical => MimirCore.Application.Models.PriorityDto.Critical,
            _ => throw new ArgumentOutOfRangeException(nameof(priority), priority, null)
        };
    }

    public static MimirCore.Api.Models.PriorityDto ToApiDto(this MimirCore.Application.Models.PriorityDto priorityDto)
    {
        return priorityDto switch
        {
            MimirCore.Application.Models.PriorityDto.Low => MimirCore.Api.Models.PriorityDto.Low,
            MimirCore.Application.Models.PriorityDto.Medium => MimirCore.Api.Models.PriorityDto.Medium,
            MimirCore.Application.Models.PriorityDto.High => MimirCore.Api.Models.PriorityDto.High,
            MimirCore.Application.Models.PriorityDto.Critical => MimirCore.Api.Models.PriorityDto.Critical,
            _ => throw new ArgumentOutOfRangeException(nameof(priorityDto), priorityDto, null)
        };
    }
    
    public static IEnumerable<MimirCore.Application.Models.PriorityDto> ToApplicationDtos(this IEnumerable<MimirCore.Api.Models.PriorityDto> priorities)
    {
        return priorities.Select(d => d.ToApplicationDto());
    }

    public static IEnumerable<MimirCore.Api.Models.PriorityDto> ToApiDtos(this IEnumerable<MimirCore.Application.Models.PriorityDto> priorities)
    {
        return priorities.Select(d => d.ToApiDto());
    }
}
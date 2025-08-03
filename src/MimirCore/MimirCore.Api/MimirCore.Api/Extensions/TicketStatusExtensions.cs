namespace MimirCore.Api.Extensions;

public static class TicketStatusExtensions
{
    public static MimirCore.Application.Models.TicketStatusDto ToApplicationDto(this MimirCore.Api.Models.TicketStatusDto ticketStatus)
    {
        return ticketStatus switch
        {
            MimirCore.Api.Models.TicketStatusDto.New => MimirCore.Application.Models.TicketStatusDto.New,
            MimirCore.Api.Models.TicketStatusDto.InProgress => MimirCore.Application.Models.TicketStatusDto.InProgress,
            MimirCore.Api.Models.TicketStatusDto.Completed => MimirCore.Application.Models.TicketStatusDto.Completed,
            MimirCore.Api.Models.TicketStatusDto.Cancelled => MimirCore.Application.Models.TicketStatusDto.Cancelled,
            MimirCore.Api.Models.TicketStatusDto.Blocked => MimirCore.Application.Models.TicketStatusDto.Blocked,
            _ => throw new ArgumentOutOfRangeException(nameof(ticketStatus), ticketStatus, null)
        };
    }

    public static MimirCore.Api.Models.TicketStatusDto ToEntity(this MimirCore.Application.Models.TicketStatusDto ticketStatusDto)
    {
        return ticketStatusDto switch
        {
            MimirCore.Application.Models.TicketStatusDto.New => MimirCore.Api.Models.TicketStatusDto.New,
            MimirCore.Application.Models.TicketStatusDto.InProgress => MimirCore.Api.Models.TicketStatusDto.InProgress,
            MimirCore.Application.Models.TicketStatusDto.Completed => MimirCore.Api.Models.TicketStatusDto.Completed,
            MimirCore.Application.Models.TicketStatusDto.Cancelled => MimirCore.Api.Models.TicketStatusDto.Cancelled,
            MimirCore.Application.Models.TicketStatusDto.Blocked => MimirCore.Api.Models.TicketStatusDto.Blocked,
            _ => throw new ArgumentOutOfRangeException(nameof(ticketStatusDto), ticketStatusDto, null)
        };
    }
    
    public static IEnumerable<MimirCore.Application.Models.TicketStatusDto> ToApplicationDtos(this IEnumerable<MimirCore.Api.Models.TicketStatusDto> priorities)
    {
        return priorities.Select(d => d.ToApplicationDto());
    }

    public static IEnumerable<MimirCore.Api.Models.TicketStatusDto> ToDomainEntities(this IEnumerable<MimirCore.Application.Models.TicketStatusDto> priorities)
    {
        return priorities.Select(d => d.ToEntity());
    }
}
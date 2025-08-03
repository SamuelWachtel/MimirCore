using MimirCore.Application.Models;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class TicketStatusExtensions
{
    public static TicketStatusDto ToApplicationDto(this TicketStatus ticketStatus)
    {
        return ticketStatus switch
        {
            TicketStatus.New => TicketStatusDto.New,
            TicketStatus.InProgress => TicketStatusDto.InProgress,
            TicketStatus.Completed => TicketStatusDto.Completed,
            TicketStatus.Cancelled => TicketStatusDto.Cancelled,
            TicketStatus.Blocked => TicketStatusDto.Blocked,
            _ => throw new ArgumentOutOfRangeException(nameof(ticketStatus), ticketStatus, null)
        };
    }

    public static TicketStatus ToEntity(this TicketStatusDto ticketStatusDto)
    {
        return ticketStatusDto switch
        {
            TicketStatusDto.New => TicketStatus.New,
            TicketStatusDto.InProgress => TicketStatus.InProgress,
            TicketStatusDto.Completed => TicketStatus.Completed,
            TicketStatusDto.Cancelled => TicketStatus.Cancelled,
            TicketStatusDto.Blocked => TicketStatus.Blocked,
            _ => throw new ArgumentOutOfRangeException(nameof(ticketStatusDto), ticketStatusDto, null)
        };
    }
    
    public static IEnumerable<TicketStatusDto> ToApplicationDtos(this IEnumerable<TicketStatus> priorities)
    {
        return priorities.Select(d => d.ToApplicationDto());
    }

    public static IEnumerable<TicketStatus> ToDomainEntities(this IEnumerable<TicketStatusDto> priorities)
    {
        return priorities.Select(d => d.ToEntity());
    }
}
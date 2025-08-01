using MimirCore.Application.Models.Ticket;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class TicketExtensions
{
    // Domain -> Application
    public static TicketDto ToApplicationDto(this Ticket ticket)
    {
        return new TicketDto
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            CategoryId = ticket.CategoryId,
            CreatedById = ticket.CreatedById,
            AssignedToId = ticket.AssignedToId,
            Priority = ticket.Priority,
            Status = ticket.Status,
            DueDate = ticket.DueDate,
            ResolvedAt = ticket.ResolvedAt,
            CreatedAt = ticket.CreatedAt,
            UpdatedAt = ticket.ModifiedAt,
        };
    }

    public static TicketItemListDto ToItemListDto(this Ticket ticket)
    {
        return new TicketItemListDto
        {
            Id = ticket.Id,
            Title = ticket.Title,
            CategoryName = ticket.Category?.Name ?? "",
            Priority = ticket.Priority,
            Status = ticket.Status,
            CreatedByName = ticket.CreatedBy != null ? $"{ticket.CreatedBy.User?.FirstName} {ticket.CreatedBy.User?.LastName}" : "",
            AssignedToName = ticket.AssignedTo != null ? $"{ticket.AssignedTo.User?.FirstName} {ticket.AssignedTo.User?.LastName}" : "",
            DueDate = ticket.DueDate,
            CreatedAt = ticket.CreatedAt
        };
    }

    // Application -> Domain
    public static Ticket ToEntity(this CreateTicketDto createTicketDto)
    {
        return new Ticket
        {
            Title = createTicketDto.Title,
            Description = createTicketDto.Description,
            CategoryId = createTicketDto.CategoryId,
            CreatedById = createTicketDto.CreatedById,
            AssignedToId = createTicketDto.AssignedToId,
            Priority = createTicketDto.Priority,
            Status = "Open",
            DueDate = createTicketDto.DueDate,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateTicketDto updateTicketDto, Ticket ticket)
    {
        ticket.Title = updateTicketDto.Title;
        ticket.Description = updateTicketDto.Description;
        ticket.CategoryId = updateTicketDto.CategoryId;
        ticket.AssignedToId = updateTicketDto.AssignedToId;
        ticket.Priority = updateTicketDto.Priority;
        ticket.Status = updateTicketDto.Status;
        ticket.DueDate = updateTicketDto.DueDate;
        ticket.ModifiedAt = DateTime.UtcNow;
    }

    // Collection extensions
    public static IEnumerable<TicketDto> ToApplicationDtos(this IEnumerable<Ticket> tickets)
    {
        return tickets.Select(t => t.ToApplicationDto());
    }

    public static IEnumerable<TicketItemListDto> ToItemListDtos(this IEnumerable<Ticket> tickets)
    {
        return tickets.Select(t => t.ToItemListDto());
    }
}
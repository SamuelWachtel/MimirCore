using MimirCore.Api.Models.Ticket;
using MimirCore.Application.Extensions;
using MimirCore.Application.Models.Ticket;
using TicketPaginatedListResponse = MimirCore.Api.Models.Ticket.TicketPaginatedListResponse;

namespace MimirCore.Api.Extensions;

public static class TicketApiExtensions
{
    public static TicketResponse ToApiDto(this Application.Models.Ticket.TicketDto ticketDto)
    {
        return new TicketResponse
        {
            Id = ticketDto.Id,
            Title = ticketDto.Title,
            Description = ticketDto.Description,
            CategoryId = ticketDto.CategoryId,
            CreatedById = ticketDto.CreatedById,
            AssignedToId = ticketDto.AssignedToId,
            Priority = ticketDto.Priority.ToApiDto(),
            TicketStatus = ticketDto.TicketStatus.ToEntity(),
            DueDate = ticketDto.DueDate,
            ResolvedAt = ticketDto.ResolvedAt,
            CreatedAt = ticketDto.CreatedAt,
            UpdatedAt = ticketDto.UpdatedAt,
            CategoryName = ticketDto.Category?.Name,
            CreatedByName = ticketDto.CreatedBy?.User != null ? $"{ticketDto.CreatedBy.User.FirstName} {ticketDto.CreatedBy.User.LastName}" : null,
            AssignedToName = ticketDto.AssignedTo?.User != null ? $"{ticketDto.AssignedTo.User.FirstName} {ticketDto.AssignedTo.User.LastName}" : null
        };
    }

    public static TicketListItemDto ToApiDto(this TicketItemListDto ticketItemDto)
    {
        return new TicketListItemDto
        {
            Id = ticketItemDto.Id,
            Title = ticketItemDto.Title,
            CategoryName = ticketItemDto.CategoryName,
            Priority = ticketItemDto.Priority.ToApiDto(),
            TicketStatus = ticketItemDto.TicketStatus.ToEntity(),
            CreatedByName = ticketItemDto.CreatedByName,
            AssignedToName = ticketItemDto.AssignedToName,
            DueDate = ticketItemDto.DueDate,
            CreatedAt = ticketItemDto.CreatedAt
        };
    }

    public static CreateTicketDto ToApplicationDto(this CreateTicketRequest createTicketRequest)
    {
        return new CreateTicketDto
        {
            Title = createTicketRequest.Title,
            Description = createTicketRequest.Description,
            CategoryId = createTicketRequest.CategoryId,
            AssignedToId = createTicketRequest.AssignedToId,
            Priority = createTicketRequest.Priority.ToApplicationDto(),
            DueDate = createTicketRequest.DueDate
        };
    }

    public static UpdateTicketDto ToApplicationDto(this UpdateTicketRequest updateTicketRequest)
    {
        return new UpdateTicketDto
        {
            Title = updateTicketRequest.Title,
            Description = updateTicketRequest.Description,
            CategoryId = updateTicketRequest.CategoryId,
            AssignedToId = updateTicketRequest.AssignedToId,
            Priority = updateTicketRequest.Priority.ToApplicationDto(),
            TicketStatus = updateTicketRequest.TicketStatus.ToApplicationDto(),
            DueDate = updateTicketRequest.DueDate,
        };
    }

    public static IEnumerable<TicketResponse> ToApiDtos(this IEnumerable<Application.Models.Ticket.TicketDto> tickets)
    {
        return tickets.Select(t => t.ToApiDto());
    }

    public static IEnumerable<TicketListItemDto> ToApiDtos(this IEnumerable<TicketItemListDto> tickets)
    {
        return tickets.Select(t => t.ToApiDto());
    }

    public static TicketPaginatedListResponse ToApiResponse(this Application.Models.Ticket.TicketPaginatedListResponse appResponse)
    {
        return new TicketPaginatedListResponse(
            appResponse.Items.ToApiDtos().ToList(),
            appResponse.PageNumber,
            appResponse.PageSize,
            appResponse.TotalCount
        );
    }
}
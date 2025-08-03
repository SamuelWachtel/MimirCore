using MimirCore.Application.Models.Ticket;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class TicketCategoryExtensions
{
    public static TicketCategoryDto ToApplicationDto(this TicketCategory ticketCategory)
    {
        return new TicketCategoryDto
        {
            Id = ticketCategory.Id,
            Name = ticketCategory.Name,
            Description = ticketCategory.Description,
            CreatedAt = ticketCategory.CreatedAt,
            UpdatedAt = ticketCategory.ModifiedAt
        };
    }

    public static TicketCategoryItemListDto ToItemListDto(this TicketCategory ticketCategory)
    {
        return new TicketCategoryItemListDto
        {
            Id = ticketCategory.Id,
            Name = ticketCategory.Name,
            Description = ticketCategory.Description,
        };
    }

    public static IEnumerable<TicketCategoryDto> ToApplicationDtos(this IEnumerable<TicketCategory> ticketCategories)
    {
        return ticketCategories.Select(tc => tc.ToApplicationDto());
    }

    public static IEnumerable<TicketCategoryItemListDto> ToItemListDtos(this IEnumerable<TicketCategory> ticketCategories)
    {
        return ticketCategories.Select(tc => tc.ToItemListDto());
    }
}
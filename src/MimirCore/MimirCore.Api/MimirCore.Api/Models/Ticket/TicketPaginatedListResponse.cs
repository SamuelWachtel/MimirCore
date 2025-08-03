using MimirCore.Api.Models.Common;

namespace MimirCore.Api.Models.Ticket;

public class TicketPaginatedListResponse : PaginatedListResponse<TicketListItemDto>
{
    public TicketPaginatedListResponse(IList<TicketListItemDto> items, int pageNumber, int pageSize, int totalCount) 
        : base(items, pageNumber, pageSize, totalCount)
    {
    }
}
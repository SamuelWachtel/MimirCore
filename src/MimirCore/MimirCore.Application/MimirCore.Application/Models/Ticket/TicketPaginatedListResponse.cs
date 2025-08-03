using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.Ticket;

public class TicketPaginatedListResponse : PaginatedListResponse<TicketItemListDto>
{
    public TicketPaginatedListResponse() : base() { }
    
    public TicketPaginatedListResponse(IList<TicketItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new TicketPaginatedListResponse Create(IList<TicketItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new TicketPaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
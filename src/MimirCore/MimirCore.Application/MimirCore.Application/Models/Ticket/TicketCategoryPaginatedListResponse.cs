using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.Ticket;

// Ticket Category Paginated List Response
public class TicketCategoryPaginatedListResponse : PaginatedListResponse<TicketCategoryItemListDto>
{
    public TicketCategoryPaginatedListResponse() : base() { }
    
    public TicketCategoryPaginatedListResponse(IList<TicketCategoryItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new TicketCategoryPaginatedListResponse Create(IList<TicketCategoryItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new TicketCategoryPaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
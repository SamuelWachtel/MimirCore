using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.Shift;

// Shift Paginated List Response
public class ShiftPaginatedListResponse : PaginatedListResponse<ShiftItemListDto>
{
    public ShiftPaginatedListResponse() : base() { }
    
    public ShiftPaginatedListResponse(IList<ShiftItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new ShiftPaginatedListResponse Create(IList<ShiftItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new ShiftPaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
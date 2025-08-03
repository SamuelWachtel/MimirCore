using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.Position;

public class PositionPaginatedListResponse : PaginatedListResponse<PositionItemListDto>
{
    public PositionPaginatedListResponse() : base() { }
    
    public PositionPaginatedListResponse(IList<PositionItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new PositionPaginatedListResponse Create(IList<PositionItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new PositionPaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
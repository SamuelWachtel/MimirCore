using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.Leave;

// Leave Request Paginated List Response
public class LeaveRequestPaginatedListResponse : PaginatedListResponse<LeaveRequestItemListDto>
{
    public LeaveRequestPaginatedListResponse() : base() { }
    
    public LeaveRequestPaginatedListResponse(IList<LeaveRequestItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new LeaveRequestPaginatedListResponse Create(IList<LeaveRequestItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new LeaveRequestPaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
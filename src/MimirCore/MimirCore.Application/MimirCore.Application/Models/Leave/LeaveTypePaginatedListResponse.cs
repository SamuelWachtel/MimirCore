using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.Leave;

// Leave Type Paginated List Response
public class LeaveTypePaginatedListResponse : PaginatedListResponse<LeaveTypeItemListDto>
{
    public LeaveTypePaginatedListResponse() : base() { }
    
    public LeaveTypePaginatedListResponse(IList<LeaveTypeItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new LeaveTypePaginatedListResponse Create(IList<LeaveTypeItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new LeaveTypePaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
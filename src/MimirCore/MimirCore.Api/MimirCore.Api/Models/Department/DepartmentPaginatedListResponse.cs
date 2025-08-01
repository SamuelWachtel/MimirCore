using MimirCore.Api.Models.Common;

namespace MimirCore.Api.Models.Department;

public class DepartmentPaginatedListResponse : PaginatedListResponse<DepartmentListItemDto>
{
    public DepartmentPaginatedListResponse() : base() { }
    
    public DepartmentPaginatedListResponse(IList<DepartmentListItemDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new DepartmentPaginatedListResponse Create(IList<DepartmentListItemDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new DepartmentPaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.Department;

// Department Paginated List Response
public class DepartmentPaginatedListResponse : PaginatedListResponse<DepartmentItemListDto>
{
    public DepartmentPaginatedListResponse() : base() { }
    
    public DepartmentPaginatedListResponse(IList<DepartmentItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new DepartmentPaginatedListResponse Create(IList<DepartmentItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new DepartmentPaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
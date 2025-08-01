using MimirCore.Api.Models.Common;

namespace MimirCore.Api.Models.Employee;

public class EmployeePaginatedListResponse : PaginatedListResponse<EmployeeListItemDto>
{
    public EmployeePaginatedListResponse() : base() { }
    
    public EmployeePaginatedListResponse(IList<EmployeeListItemDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new EmployeePaginatedListResponse Create(IList<EmployeeListItemDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new EmployeePaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
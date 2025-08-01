using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.Employee;

// Employee Paginated List Response
public class EmployeePaginatedListResponse : PaginatedListResponse<EmployeeItemListDto>
{
    public EmployeePaginatedListResponse() : base() { }
    
    public EmployeePaginatedListResponse(IList<EmployeeItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new EmployeePaginatedListResponse Create(IList<EmployeeItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new EmployeePaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
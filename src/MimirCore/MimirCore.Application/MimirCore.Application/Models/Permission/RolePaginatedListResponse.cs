using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.Permission;

// Role Paginated List Response
public class RolePaginatedListResponse : PaginatedListResponse<RoleItemListDto>
{
    public RolePaginatedListResponse() : base() { }
    
    public RolePaginatedListResponse(IList<RoleItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new RolePaginatedListResponse Create(IList<RoleItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new RolePaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
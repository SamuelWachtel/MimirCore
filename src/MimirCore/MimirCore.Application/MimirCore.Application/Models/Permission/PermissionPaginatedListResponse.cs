using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.Permission;

// Permission Paginated List Response
public class PermissionPaginatedListResponse : PaginatedListResponse<PermissionItemListDto>
{
    public PermissionPaginatedListResponse() : base() { }
    
    public PermissionPaginatedListResponse(IList<PermissionItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new PermissionPaginatedListResponse Create(IList<PermissionItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new PermissionPaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
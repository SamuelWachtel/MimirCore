namespace MimirCore.Api.Models.Permission;

public class PermissionPaginatedListResponse
{
    public IEnumerable<PermissionItemListDto> Items { get; set; } = new List<PermissionItemListDto>();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
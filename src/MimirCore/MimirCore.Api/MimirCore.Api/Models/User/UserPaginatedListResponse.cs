using MimirCore.Api.Models.Common;

namespace MimirCore.Api.Models.User;

public class UserPaginatedListResponse : PaginatedListResponse<UserListItemDto>
{
    public UserPaginatedListResponse() : base() { }
    
    public UserPaginatedListResponse(IList<UserListItemDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new UserPaginatedListResponse Create(IList<UserListItemDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new UserPaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
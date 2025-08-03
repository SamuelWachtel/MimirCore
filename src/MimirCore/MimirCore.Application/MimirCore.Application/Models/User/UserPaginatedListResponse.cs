using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.User;

public class UserPaginatedListResponse : PaginatedListResponse<UserItemListDto>
{
    public UserPaginatedListResponse() : base() { }
    
    public UserPaginatedListResponse(IList<UserItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new UserPaginatedListResponse Create(IList<UserItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new UserPaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
using MimirCore.Api.Models.Common;

namespace MimirCore.Api.Models.Team;

// Team Paginated List API Response
public class TeamPaginatedListResponse : PaginatedListResponse<TeamListItemDto>
{
    public TeamPaginatedListResponse(IList<TeamListItemDto> items, int pageNumber, int pageSize, int totalCount) 
        : base(items, pageNumber, pageSize, totalCount)
    {
    }
}
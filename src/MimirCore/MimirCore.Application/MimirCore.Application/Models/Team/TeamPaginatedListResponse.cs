using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Models.Team;

// Team Paginated List Response
public class TeamPaginatedListResponse : PaginatedListResponse<TeamItemListDto>
{
    public TeamPaginatedListResponse() : base() { }
    
    public TeamPaginatedListResponse(IList<TeamItemListDto> items, int pageNumber, int pageSize, int totalCount)
        : base(items, pageNumber, pageSize, totalCount) { }

    public static new TeamPaginatedListResponse Create(IList<TeamItemListDto> items, int pageNumber, int pageSize, int totalCount)
    {
        return new TeamPaginatedListResponse(items, pageNumber, pageSize, totalCount);
    }
}
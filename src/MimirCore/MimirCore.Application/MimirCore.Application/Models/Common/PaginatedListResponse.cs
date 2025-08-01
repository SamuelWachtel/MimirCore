namespace MimirCore.Application.Models.Common;

public class PaginatedListResponse<T>
{
    public IList<T> Items { get; set; } = new List<T>();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }

    public PaginatedListResponse()
    {
    }

    public PaginatedListResponse(IList<T> items, int pageNumber, int pageSize, int totalCount)
    {
        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        HasPreviousPage = pageNumber > 1;
        HasNextPage = pageNumber < TotalPages;
    }

    public static PaginatedListResponse<T> Create(IList<T> items, int pageNumber, int pageSize, int totalCount)
    {
        return new PaginatedListResponse<T>(items, pageNumber, pageSize, totalCount);
    }
}
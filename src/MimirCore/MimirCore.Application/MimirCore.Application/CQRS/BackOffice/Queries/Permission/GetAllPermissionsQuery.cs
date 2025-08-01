using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Permission;

namespace MimirCore.Application.CQRS.BackOffice.Queries.Permission;

public class GetAllPermissionsQuery : IQuery<PermissionPaginatedListResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Category { get; set; }
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; } = "Category";
    public string? SortOrder { get; set; } = "asc";
}

public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, PermissionPaginatedListResponse>
{
    private readonly IApplicationDbContext _context;

    public GetAllPermissionsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PermissionPaginatedListResponse> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
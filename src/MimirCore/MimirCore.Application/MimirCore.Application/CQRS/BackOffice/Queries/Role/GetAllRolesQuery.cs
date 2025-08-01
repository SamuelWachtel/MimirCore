using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Permission;

namespace MimirCore.Application.CQRS.BackOffice.Queries.Role;

public class GetAllRolesQuery : IQuery<RolePaginatedListResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; } = "Name";
    public string? SortOrder { get; set; } = "asc";
}

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, RolePaginatedListResponse>
{
    private readonly IApplicationDbContext _context;

    public GetAllRolesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RolePaginatedListResponse> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
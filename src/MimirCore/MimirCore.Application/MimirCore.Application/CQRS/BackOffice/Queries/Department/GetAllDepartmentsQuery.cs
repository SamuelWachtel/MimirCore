using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Department;

namespace MimirCore.Application.CQRS.BackOffice.Queries.Department;

public class GetAllDepartmentsQuery : IQuery<DepartmentPaginatedListResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }
    public int? ParentDepartmentId { get; set; }
    public string? SortBy { get; set; } = "Name";
    public string? SortOrder { get; set; } = "asc";
}

public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, DepartmentPaginatedListResponse>
{
    private readonly IApplicationDbContext _context;

    public GetAllDepartmentsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DepartmentPaginatedListResponse> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
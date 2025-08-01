using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Employee;

namespace MimirCore.Application.CQRS.BackOffice.Queries.Employee;

public class GetAllEmployeesQuery : IQuery<EmployeePaginatedListResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }
    public string? Status { get; set; }
    public int? TeamId { get; set; }
    public int? PositionId { get; set; }
    public string? SortBy { get; set; } = "CreatedAt";
    public string? SortOrder { get; set; } = "desc";
}

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, EmployeePaginatedListResponse>
{
    private readonly IApplicationDbContext _context;

    public GetAllEmployeesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EmployeePaginatedListResponse> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
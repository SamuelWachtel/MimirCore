using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Shift;

namespace MimirCore.Application.CQRS.BackOffice.Queries.Shift;

public class GetAllShiftsQuery : IQuery<ShiftPaginatedListResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public Guid? EmployeeId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Status { get; set; }
    public string? SortBy { get; set; } = "StartTime";
    public string? SortOrder { get; set; } = "desc";
}

public class GetAllShiftsQueryHandler : IRequestHandler<GetAllShiftsQuery, ShiftPaginatedListResponse>
{
    private readonly IApplicationDbContext _context;

    public GetAllShiftsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ShiftPaginatedListResponse> Handle(GetAllShiftsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
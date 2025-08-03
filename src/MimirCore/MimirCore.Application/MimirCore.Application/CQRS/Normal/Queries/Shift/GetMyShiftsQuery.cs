using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Shift;

namespace MimirCore.Application.CQRS.Normal.Queries.Shift;

public class GetMyShiftsQuery : IQuery<ShiftPaginatedListResponse>
{
    public Guid EmployeeId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetMyShiftsQueryHandler : IRequestHandler<GetMyShiftsQuery, ShiftPaginatedListResponse>
{
    private readonly IApplicationDbContext _context;

    public GetMyShiftsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ShiftPaginatedListResponse> Handle(GetMyShiftsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Leave;

namespace MimirCore.Application.CQRS.Normal.Queries.Leave;

public class GetMyLeaveRequestsQuery : IQuery<LeaveRequestPaginatedListResponse>
{
    public int EmployeeId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Status { get; set; }
}

public class GetMyLeaveRequestsQueryHandler : IRequestHandler<GetMyLeaveRequestsQuery, LeaveRequestPaginatedListResponse>
{
    private readonly IApplicationDbContext _context;

    public GetMyLeaveRequestsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<LeaveRequestPaginatedListResponse> Handle(GetMyLeaveRequestsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
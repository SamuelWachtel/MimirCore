using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Leave;

namespace MimirCore.Application.CQRS.Normal.Queries.Leave;

public class GetAvailableLeaveTypesQuery : IQuery<IEnumerable<LeaveTypeItemListDto>>
{
}

public class GetAvailableLeaveTypesQueryHandler : IRequestHandler<GetAvailableLeaveTypesQuery, IEnumerable<LeaveTypeItemListDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAvailableLeaveTypesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LeaveTypeItemListDto>> Handle(GetAvailableLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
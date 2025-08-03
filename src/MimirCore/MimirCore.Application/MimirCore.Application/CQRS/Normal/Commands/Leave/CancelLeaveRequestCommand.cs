using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;

namespace MimirCore.Application.CQRS.Normal.Commands.Leave;

public class CancelLeaveRequestCommand : ICommand
{
    public Guid LeaveRequestId { get; set; }
    public Guid EmployeeId { get; set; }
}

public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand>
{
    private readonly IApplicationDbContext _context;

    public CancelLeaveRequestCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
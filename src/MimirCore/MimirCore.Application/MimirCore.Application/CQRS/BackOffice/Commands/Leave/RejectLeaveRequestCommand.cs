using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;

namespace MimirCore.Application.CQRS.BackOffice.Commands.Leave;

public class RejectLeaveRequestCommand : ICommand
{
    public int LeaveRequestId { get; set; }
    public int RejectedById { get; set; }
    public string Reason { get; set; }
}

public class RejectLeaveRequestCommandHandler : IRequestHandler<RejectLeaveRequestCommand>
{
    private readonly IApplicationDbContext _context;

    public RejectLeaveRequestCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RejectLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;

namespace MimirCore.Application.CQRS.BackOffice.Commands.Leave;

public class ApproveLeaveRequestCommand : ICommand
{
    public int LeaveRequestId { get; set; }
    public int ApprovedById { get; set; }
    public string? Comments { get; set; }
}

public class ApproveLeaveRequestCommandHandler : IRequestHandler<ApproveLeaveRequestCommand>
{
    private readonly IApplicationDbContext _context;

    public ApproveLeaveRequestCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(ApproveLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
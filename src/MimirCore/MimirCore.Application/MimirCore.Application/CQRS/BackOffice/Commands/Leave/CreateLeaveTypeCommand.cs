using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Leave;

namespace MimirCore.Application.CQRS.BackOffice.Commands.Leave;

public class CreateLeaveTypeCommand : ICommand<LeaveTypeDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int DefaultDays { get; set; }
    public bool RequiresApproval { get; set; } = true;
}

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, LeaveTypeDto>
{
    private readonly IApplicationDbContext _context;

    public CreateLeaveTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<LeaveTypeDto> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
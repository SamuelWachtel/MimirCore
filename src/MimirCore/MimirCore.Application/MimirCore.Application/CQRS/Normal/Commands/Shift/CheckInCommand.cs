using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;

namespace MimirCore.Application.CQRS.Normal.Commands.Shift;

public class CheckInCommand : ICommand
{
    public int ShiftId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime CheckInTime { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }
}

public class CheckInCommandHandler : IRequestHandler<CheckInCommand>
{
    private readonly IApplicationDbContext _context;

    public CheckInCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CheckInCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;

namespace MimirCore.Application.CQRS.Normal.Commands.Shift;

public class CheckOutCommand : ICommand
{
    public int ShiftId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime CheckOutTime { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }
}

public class CheckOutCommandHandler : IRequestHandler<CheckOutCommand>
{
    private readonly IApplicationDbContext _context;

    public CheckOutCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CheckOutCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
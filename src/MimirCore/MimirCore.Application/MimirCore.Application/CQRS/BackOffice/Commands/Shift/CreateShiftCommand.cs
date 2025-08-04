using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Shift;

namespace MimirCore.Application.CQRS.BackOffice.Commands.Shift;

public class CreateShiftCommand : ICommand<ShiftDto>
{
    public Guid EmployeeId { get; set; }
    public Guid? ShiftTemplateId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Notes { get; set; }
}

public class CreateShiftCommandHandler : IRequestHandler<CreateShiftCommand, ShiftDto>
{
    private readonly IApplicationDbContext _context;

    public CreateShiftCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ShiftDto> Handle(CreateShiftCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
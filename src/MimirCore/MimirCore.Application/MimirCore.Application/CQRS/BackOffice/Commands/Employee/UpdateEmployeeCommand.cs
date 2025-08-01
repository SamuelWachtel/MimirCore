using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Employee;

namespace MimirCore.Application.CQRS.BackOffice.Commands.Employee;

public class UpdateEmployeeCommand : ICommand<EmployeeDto>
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public int PositionId { get; set; }
    public decimal Salary { get; set; }
    public string EmploymentType { get; set; }
    public string Status { get; set; }
    public DateTime? TerminationDate { get; set; }
}

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;

namespace MimirCore.Application.CQRS.BackOffice.Commands.Employee;

public class DeleteEmployeeCommand : ICommand
{
    public int Id { get; set; }
    public DateTime TerminationDate { get; set; }
    public string Reason { get; set; }
}

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
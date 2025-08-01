using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Department;

namespace MimirCore.Application.CQRS.BackOffice.Commands.Department;

public class UpdateDepartmentCommand : ICommand<DepartmentDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? ChiefId { get; set; }
    public int? ParentDepartmentId { get; set; }
}

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, DepartmentDto>
{
    private readonly IApplicationDbContext _context;

    public UpdateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DepartmentDto> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
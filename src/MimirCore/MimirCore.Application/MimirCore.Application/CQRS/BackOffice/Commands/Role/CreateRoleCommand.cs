using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Permission;

namespace MimirCore.Application.CQRS.BackOffice.Commands.Role;

public class CreateRoleCommand : ICommand<RoleDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<int> PermissionIds { get; set; } = new();
}

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RoleDto>
{
    private readonly IApplicationDbContext _context;

    public CreateRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
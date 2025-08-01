using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Permission;

namespace MimirCore.Application.CQRS.BackOffice.Commands.Role;

public class UpdateRoleCommand : ICommand<RoleDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<int> PermissionIds { get; set; } = new();
}

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RoleDto>
{
    private readonly IApplicationDbContext _context;

    public UpdateRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RoleDto> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Permission;

namespace MimirCore.Application.CQRS.BackOffice.Commands.Permission;

public class CreatePermissionCommand : ICommand<PermissionDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}

public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, PermissionDto>
{
    private readonly IApplicationDbContext _context;

    public CreatePermissionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PermissionDto> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
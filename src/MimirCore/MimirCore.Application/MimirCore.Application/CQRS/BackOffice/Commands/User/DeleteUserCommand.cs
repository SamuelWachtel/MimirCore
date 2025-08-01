using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;

namespace MimirCore.Application.CQRS.BackOffice.Commands.User;

public class DeleteUserCommand : ICommand
{
    public int Id { get; set; }
    
    public DeleteUserCommand(int id)
    {
        Id = id;
    }
}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
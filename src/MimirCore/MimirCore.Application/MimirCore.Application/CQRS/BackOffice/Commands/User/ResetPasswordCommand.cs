using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;

namespace MimirCore.Application.CQRS.BackOffice.Commands.User;

public class ResetPasswordCommand : ICommand
{
    public int UserId { get; set; }
    public string NewPassword { get; set; }
    public bool RequirePasswordChange { get; set; } = true;
}

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
{
    private readonly IApplicationDbContext _context;

    public ResetPasswordCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
using MediatR;

namespace MimirCore.Application.CQRS.Common;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
using MediatR;
using MinimalApi.Application.Common.Utilities;

namespace MinimalApi.Application.Abstraction.MediatR;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
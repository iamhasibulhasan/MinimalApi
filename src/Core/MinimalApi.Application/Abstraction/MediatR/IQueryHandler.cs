using MediatR;
using MinimalApi.Application.Common.Utilities;

namespace MinimalApi.Application.Abstraction.MediatR;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}

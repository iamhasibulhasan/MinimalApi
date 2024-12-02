﻿using MediatR;
using MinimalApi.Application.Common.Utilities;

namespace MinimalApi.Application.Abstraction.MediatR;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}

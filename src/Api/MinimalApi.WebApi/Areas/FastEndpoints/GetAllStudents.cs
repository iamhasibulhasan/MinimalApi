using FastEndpoints;
using MediatR;
using MinimalApi.Application.Common.Utilities;
using MinimalApi.Application.Features.Students.Queries.GetAll;

namespace MinimalApi.WebApi.Areas.FastEndpoints;

public class GetAllStudents : EndpointWithoutRequest<Result>
{
    private readonly IMediator _mediator;

    public GetAllStudents(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override void Configure()
    {
        Get("api/fastendpoints/student");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        Result result;
        var query = new GetAllStudentQuery();
        result = await _mediator.Send(query, cancellationToken);
        await SendAsync(result, result.StatusCode);
    }
}



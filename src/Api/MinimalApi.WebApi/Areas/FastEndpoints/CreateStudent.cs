using FastEndpoints;
using MediatR;
using MinimalApi.Application.Common.Utilities;
using MinimalApi.Application.Features.Students.Command.Create;
using MinimalApi.Application.Features.Students.Command.Dto;

namespace MinimalApi.WebApi.Areas.FastEndpoints
{
    public class CreateStudent : Endpoint<CreateStudentDto, Result>
    {
        private readonly IMediator _mediator;

        public CreateStudent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Post("api/fastendpoints/student/");
            AllowAnonymous();
            DontThrowIfValidationFails();
        }

        public override async Task HandleAsync(CreateStudentDto req, CancellationToken cancellationToken)
        {
            var validationResult = new CreateStudentDtoValidator().Validate(req);
            Result result;
            if (!validationResult.IsValid)
            {
                result = Utility.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
                ThrowIfAnyErrors(statusCode: result.StatusCode);
            }
            else
            {
                var command = new CreateStudentCommand(req);
                result = await _mediator.Send(command, cancellationToken);
            }
            await SendAsync(result, result.StatusCode, cancellation: cancellationToken);

        }
    }
}

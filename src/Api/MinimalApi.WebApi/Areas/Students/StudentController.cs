using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Application.Common.Utilities;
using MinimalApi.Application.Features.Students.Command.Create;
using MinimalApi.Application.Features.Students.Command.Dto;

namespace MinimalApi.WebApi.Areas.Students;

public class StudentController : BaseApiController
{
    private readonly IMediator _mediator;
    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Command

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateStudentDto model, CancellationToken cancellationToken = default)
    {
        var validationResult = new CreateStudentDtoValidator().Validate(model);

        if (!validationResult.IsValid)
        {
            Result result = Utility.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
            return StatusCode(result.StatusCode, result);
        }
        var command = new CreateStudentCommand(model);
        var _result = await _mediator.Send(command, cancellationToken);

        return StatusCode(_result.StatusCode, _result);
    }



    #endregion
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Application.Common.Utilities;
using MinimalApi.Application.Features.Students.Command.Create;
using MinimalApi.Application.Features.Students.Command.Delete;
using MinimalApi.Application.Features.Students.Command.Dto;
using MinimalApi.Application.Features.Students.Command.Update;
using MinimalApi.Application.Features.Students.Queries.GetAll;
using MinimalApi.Application.Features.Students.Queries.GetById;

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

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateStudentDto model, CancellationToken cancellationToken = default)
    {
        var validationResult = new UpdateStudentDtoValidator().Validate(model);

        if (!validationResult.IsValid)
        {
            Result result = Utility.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
            return StatusCode(result.StatusCode, result);
        }
        var command = new UpdateStudentCommand(model);
        var _result = await _mediator.Send(command, cancellationToken);

        return StatusCode(_result.StatusCode, _result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
    {

        Result result;
        if (id <= 0)
        {
            result = Utility.GetValidationFailedMsg(CommonMessages.InvalidId);
        }
        else
        {
            var command = new DeleteStudentCommand(id);
            result = await _mediator.Send(command, cancellationToken);
        }

        return StatusCode(result.StatusCode, result);
    }

    #endregion

    #region Queries

    [HttpGet()]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        Result result;
        var command = new GetAllStudentQuery();
        result = await _mediator.Send(command, cancellationToken);
        if (result.Data is null)
        {
            return StatusCode(result.StatusCode, result);
        }
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
    {
        Result result;
        var command = new GetByIdStudentQuery(id);
        result = await _mediator.Send(command, cancellationToken);
        if (result.Data is null)
        {
            return StatusCode(result.StatusCode, result);
        }
        return StatusCode(result.StatusCode, result);
    }
    #endregion
}

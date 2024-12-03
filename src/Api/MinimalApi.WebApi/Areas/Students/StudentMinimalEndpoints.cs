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

public static class StudentMinimalEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/minimal/student");

        group.MapPost("", CreateStudent).WithName(nameof(CreateStudent));
        group.MapPut("", UpdateStudent).WithName(nameof(UpdateStudent));
        group.MapDelete("{id}", DeleteStudent).WithName(nameof(DeleteStudent));
        group.MapGet("{id}", GetById).WithName(nameof(GetById));
        group.MapGet("", GetAll).WithName(nameof(GetAll));
    }

    #region Command

    public static async Task<IResult> CreateStudent(
        IMediator mediator,
        [FromBody] CreateStudentDto model,
        CancellationToken cancellationToken = default)
    {
        var validationResult = new CreateStudentDtoValidator().Validate(model);

        if (!validationResult.IsValid)
        {
            Result result = Utility.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
            return Results.Json(result, statusCode: result.StatusCode);
        }
        var command = new CreateStudentCommand(model);
        var _result = await mediator.Send(command, cancellationToken);

        return Results.Json(_result, statusCode: _result.StatusCode);
    }

    public static async Task<IResult> UpdateStudent(
        IMediator mediator,
        [FromBody] UpdateStudentDto model,
        CancellationToken cancellationToken = default)
    {
        var validationResult = new UpdateStudentDtoValidator().Validate(model);

        if (!validationResult.IsValid)
        {
            Result result = Utility.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
            return Results.Json(result, statusCode: result.StatusCode);
        }
        var command = new UpdateStudentCommand(model);
        var _result = await mediator.Send(command, cancellationToken);

        return Results.Json(_result, statusCode: _result.StatusCode);
    }

    public static async Task<IResult> DeleteStudent(
        IMediator mediator,
        int id,
        CancellationToken cancellationToken = default)
    {

        Result result;
        if (id <= 0)
        {
            result = Utility.GetValidationFailedMsg(CommonMessages.InvalidId);
        }
        else
        {
            var command = new DeleteStudentCommand(id);
            result = await mediator.Send(command, cancellationToken);
        }

        return Results.Json(result, statusCode: result.StatusCode);
    }

    #endregion

    #region Queries

    public static async Task<IResult> GetAll(
        IMediator mediator,
        CancellationToken cancellationToken = default)
    {
        Result result;
        var command = new GetAllStudentQuery();
        result = await mediator.Send(command, cancellationToken);
        if (result.Data is null)
        {
            return Results.Json(result, statusCode: result.StatusCode);
        }
        return Results.Json(result, statusCode: result.StatusCode);
    }

    public static async Task<IResult> GetById(
        IMediator mediator,
        int id,
        CancellationToken cancellationToken = default)
    {
        Result result;
        var command = new GetByIdStudentQuery(id);
        result = await mediator.Send(command, cancellationToken);
        if (result.Data is null)
        {
            return Results.Json(result, statusCode: result.StatusCode);
        }
        return Results.Json(result, statusCode: result.StatusCode);
    }
    #endregion

}

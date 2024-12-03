using MinimalApi.Application.Abstraction.MediatR;
using MinimalApi.Application.Features.Students.Command.Dto;

namespace MinimalApi.Application.Features.Students.Command.Update;

public sealed record UpdateStudentCommand(UpdateStudentDto model) : ICommand;

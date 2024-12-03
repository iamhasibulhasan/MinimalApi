using MinimalApi.Application.Abstraction.MediatR;
using MinimalApi.Application.Features.Students.Command.Dto;

namespace MinimalApi.Application.Features.Students.Command.Create;

public sealed record CreateStudentCommand(CreateStudentDto model) : ICommand;

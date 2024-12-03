using MinimalApi.Application.Abstraction.MediatR;
using MinimalApi.Application.Common.Utilities;

namespace MinimalApi.Application.Features.Students.Queries.GetAll;

public sealed record GetAllStudentQuery() : IQuery<Result>;

using MinimalApi.Application.Abstraction.MediatR;
using MinimalApi.Application.Common.Utilities;

namespace MinimalApi.Application.Features.Students.Queries.GetById;

public sealed record GetByIdStudentQuery(int id) : IQuery<Result>;

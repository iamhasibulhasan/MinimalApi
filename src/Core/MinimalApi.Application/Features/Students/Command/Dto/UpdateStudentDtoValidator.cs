using FluentValidation;

namespace MinimalApi.Application.Features.Students.Command.Dto;

public sealed class UpdateStudentDtoValidator : AbstractValidator<UpdateStudentDto>
{
    public UpdateStudentDtoValidator()
    {
        RuleFor(x => x.StudentCode).NotEmpty().WithMessage("{PropertyName} is required!");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("{PropertyName} is required!");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("{PropertyName} is required!");
        RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("{PropertyName} is required!");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("{PropertyName} is required!");
        RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required!");
    }
}

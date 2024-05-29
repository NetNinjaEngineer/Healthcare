using FluentValidation;
using Healthcare.Application.DTOs;

namespace Healthcare.Application.Commands.CreateEmployee;
public sealed class CreateEmployeeCommandValidator : AbstractValidator<EmployeeForManipulateDto>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(p => p.FirstName)
            .NotNull().WithMessage("FirstName can not be null.")
            .NotEmpty().WithMessage("FirstName is required.")
            .MaximumLength(50).WithMessage("The Maximum characters for firstName is 50 character.");

        RuleFor(p => p.LastName)
            .NotNull().WithMessage("LastName can not be null.")
            .NotEmpty().WithMessage("LastName is required.")
            .MaximumLength(50).WithMessage("The Maximum characters for lastName is 50 character.");

        RuleFor(p => p.JobTitle)
           .NotNull().WithMessage("JobTitle can not be null.")
           .NotEmpty().WithMessage("JobTitle is required.")
           .MaximumLength(20).WithMessage("The Maximum characters for jobTitle is 20 character.");
    }
}

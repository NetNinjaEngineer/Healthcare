using FluentValidation;
using Healthcare.Application.DTOs.Employee;

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

        RuleFor(p => p.Gender)
            .IsInEnum().WithMessage("Invalid gender value.");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("Email address can not be empty.")
            .EmailAddress().WithMessage("Invalid email address format.");


        RuleFor(p => p.Salary)
            .NotEmpty().WithMessage("Salary is required.")
            .GreaterThan(0).WithMessage("Salary must be greater than zero.");


        RuleFor(dto => dto.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?[0-9]{3,}$").WithMessage("Invalid phone number format.");

        RuleFor(dto => dto.HireDate)
            .NotEmpty().WithMessage("Hire date is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Hire date cannot be in the future.");

        RuleFor(dto => dto.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required.")
            .LessThan(DateTime.Now).WithMessage("Date of birth cannot be in the future.");
    }
}

using FluentValidation;
using Healthcare.Application.DTOs.Patient;

namespace Healthcare.Application.Commands.CreatePatient;
public class CreatePatientCommandValidator : AbstractValidator<PatientForCreateDto>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(p => p.FirstName)
            .NotNull().WithMessage("First name can not be null.")
            .NotEmpty().WithMessage("First name is required.");

        RuleFor(p => p.LastName)
            .NotNull().WithMessage("Last name can not be null.")
            .NotEmpty().WithMessage("Last name is required.");

        RuleFor(p => p.Email)
         .NotNull().WithMessage("Email Address can not be null.")
         .NotEmpty().WithMessage("Email Address is required.")
         .MaximumLength(125).WithMessage("Email must have maximum lenght 125 characters.")
         .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
         .WithMessage("Invalid email address format.");


        RuleFor(p => p.Phone)
        .NotNull().WithMessage("Phone can not be null.")
        .NotEmpty().WithMessage("Phone is required.")
        .MaximumLength(20).WithMessage("Phone must have maximum lenght 20 characters.")
        .Matches("@\"^\\+?[0-9]{3,}$\"");


        RuleFor(p => p.Gender)
            .IsInEnum().WithMessage("Invalid gender value.");

    }
}

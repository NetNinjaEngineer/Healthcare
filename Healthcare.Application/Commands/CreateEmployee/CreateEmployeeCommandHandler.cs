using AutoMapper;
using FluentValidation;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using Healthcare.Domain.FluentBuilders;
using MediatR;

namespace Healthcare.Application.Commands.CreateEmployee;
public sealed class CreateEmployeeCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<CreateEmployeeCommand, EmployeeForListDto>
{
    public async Task<EmployeeForListDto> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        await new CreateEmployeeCommandValidator()
            .ValidateAndThrowAsync(request.Employee, cancellationToken);

        var employee = mapper.Map<Employee>(request.Employee);

        var emp =
            EmployeeBuilder
            .Empty()
            .WithFirstName(request.Employee.FirstName ?? "")
            .WithLastName(request.Employee.LastName ?? "")
            .WithSalary(request.Employee.Salary)
            .WithEmail(request.Employee.Email ?? "")
            .WithGender(request.Employee.Gender)
            .WithJobTitle(request.Employee.JobTitle)
            .WithAddress(address =>
                address
                .Streat(request.Employee.Address.Street ?? "")
                .State(request.Employee.Address.State ?? "")
                .City(request.Employee.Address.City ?? "")
                .Country(request.Employee.Address.Country ?? "")
                .PostalCode(request.Employee.Address.PostalCode ?? "")
                )
            .WithBirthDate(request.Employee.DateOfBirth)
            .WithPhone(request.Employee.Phone)
            .WithHireDate(request.Employee.HireDate)
            .Build();


        unitOfWork.EmployeeRepository.Create(emp);

        await unitOfWork.CommitAsync();

        return mapper.Map<EmployeeForListDto>(emp);
    }
}

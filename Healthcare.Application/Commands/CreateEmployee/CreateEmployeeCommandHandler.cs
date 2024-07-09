using AutoMapper;
using FluentValidation;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Abstractions;
using Healthcare.Domain.Entities;
using Healthcare.Domain.ValueObjects;
using MediatR;

namespace Healthcare.Application.Commands.CreateEmployee;
public sealed class CreateEmployeeCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<CreateEmployeeCommand, Result<EmployeeDto>>
{
    public async Task<Result<EmployeeDto>> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        await ValidateRequest(request, cancellationToken);

        Result<Employee> employeeResult = ValidateAndCreateEmployee(request);
        if (employeeResult.IsFailure)
            return Result<EmployeeDto>.Failure(employeeResult.Error);

        Result<bool> result = await Save(unitOfWork, employeeResult.Value);

        return result.IsFailure ?
            Result<EmployeeDto>.Failure(result.Error) :
            Result<EmployeeDto>.Success(mapper.Map<EmployeeDto>(employeeResult.Value));
    }

    private static async Task<Result<bool>> Save(IUnitOfWork unitOfWork, Employee employee)
    {
        try
        {
            unitOfWork.EmployeeRepository.Create(employee);
            await unitOfWork.CommitAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure(new Error("DB", $"Database error occured - {ex.Message}"));
        }
    }

    private static async Task ValidateRequest(CreateEmployeeCommand request,
        CancellationToken cancellationToken)
        => await new CreateEmployeeCommandValidator().ValidateAndThrowAsync(
            request.Employee,
            cancellationToken);

    private static Result<Employee> ValidateAndCreateEmployee(CreateEmployeeCommand command)
    {
        var result = CreatePhoneNumber(command.Employee.Phone!)
            .Then(phone => CreateAddress(
                command.Employee.Street!,
                command.Employee.City!,
                command.Employee.PostalCode!,
                command.Employee.State!,
                command.Employee.Country!))
            .Then(address => CreateEmployee(command));


        if (result.IsSuccess)
            return result;

        return Result<Employee>.Failure(result.Error);
    }

    private static Result<PhoneNumber> CreatePhoneNumber(string phoneNumber)
    {
        Result<PhoneNumber> phoneNumberResult = PhoneNumber.Create(phoneNumber);

        if (phoneNumberResult.IsFailure)
            return Result<PhoneNumber>.Failure(phoneNumberResult.Error);

        return phoneNumberResult;
    }

    private static Result<Address> CreateAddress(string streat, string city, string postalCode, string state, string country)
    {
        Result<Address> addressResult = Address.Create(streat, city, postalCode, state, country);
        if (addressResult.IsFailure)
            return Result<Address>.Failure(addressResult.Error);
        return addressResult;
    }

    private static Result<Employee> CreateEmployee(CreateEmployeeCommand command)
    {
        Result<Employee> employeeResult = Employee.Create(
            Guid.NewGuid().ToString(),
            command.Employee.FirstName,
            command.Employee.LastName,
            PhoneNumber.Create(command.Employee.Phone!).Value,
            command.Employee.JobTitle,
            command.Employee.Salary,
            command.Employee.DateOfBirth,
            command.Employee.HireDate,
            command.Employee.Gender,
            command.Employee.Email,
            Address.Create(
                command.Employee.Street!,
                command.Employee.City!,
                command.Employee.PostalCode!,
                command.Employee.State!,
                command.Employee.Country!
                ).Value
            );

        return employeeResult.IsFailure
            ? Result<Employee>.Failure(employeeResult.Error) : employeeResult;

    }
}

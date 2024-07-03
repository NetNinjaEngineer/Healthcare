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
    ) : IRequestHandler<CreateEmployeeCommand, Result<EmployeeForListDto>>
{
    public async Task<Result<EmployeeForListDto>> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        await ValidateRequest(request, cancellationToken);

        Result<Employee> employeeResult = ValidateAndCreateEmployee(request);
        if (employeeResult.IsFailure)
            return Result<EmployeeForListDto>.Failure(employeeResult.Error);

        Result result = await Save(unitOfWork, employeeResult.Value);

        if (result.IsFailure)
            return Result<EmployeeForListDto>.Failure(result.Error);

        return Result<EmployeeForListDto>.Success(mapper.Map<EmployeeForListDto>(employeeResult.Value));
    }

    private static async Task<Result> Save(IUnitOfWork unitOfWork, Employee employee)
    {
        unitOfWork.EmployeeRepository.Create(employee);

        return !await unitOfWork.CommitAsync() ?
            Result.Failure("Failed to save employee to the repository.") :
            Result.Success();
    }

    private static async Task ValidateRequest(CreateEmployeeCommand request,
        CancellationToken cancellationToken)
        => await new CreateEmployeeCommandValidator().ValidateAndThrowAsync(
            request.Employee,
            cancellationToken);

    private static Result<Employee> ValidateAndCreateEmployee(CreateEmployeeCommand request)
    {
        Result<PhoneNumber> phoneNumberResult = PhoneNumber.Create(request.Employee.Phone!);

        if (phoneNumberResult.IsFailure)
            return Result<Employee>.Failure(phoneNumberResult.Error);

        Result<Address> addressResult = Address.Create(
            request.Employee.Street!,
            request.Employee.City!, request.Employee.PostalCode!, request.Employee.State!,
            request.Employee.Country!);

        if (addressResult.IsFailure)
            return Result<Employee>.Failure(addressResult.Error);


        Result<Employee> employeeResult = Employee.Create(
            request.Employee.FirstName, request.Employee.LastName,
            phoneNumberResult.Value, request.Employee.JobTitle,
            request.Employee.Salary, request.Employee.DateOfBirth, request.Employee.HireDate,
            request.Employee.Gender, request.Employee.Email, addressResult.Value);

        if (employeeResult.IsFailure)
            return Result<Employee>.Failure(employeeResult.Error);

        return employeeResult;
    }
}

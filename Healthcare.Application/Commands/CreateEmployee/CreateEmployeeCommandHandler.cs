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
        await new CreateEmployeeCommandValidator()
            .ValidateAndThrowAsync(request.Employee, cancellationToken);

        Result<PhoneNumber> phoneNumberResult = PhoneNumber.Create(request.Employee.Phone!);

        if (phoneNumberResult.IsFailure)
            return Result<EmployeeForListDto>.Failure(phoneNumberResult.Error);

        Result<Address> addressResult = Address.Create(
            request.Employee.Street!,
            request.Employee.City!, request.Employee.PostalCode!, request.Employee.State!,
            request.Employee.Country!);

        if (addressResult.IsFailure)
            return Result<EmployeeForListDto>.Failure(addressResult.Error);


        Result<Employee> employeeResult = Employee.Create(
            request.Employee.FirstName, request.Employee.LastName,
            phoneNumberResult.Value, request.Employee.JobTitle,
            request.Employee.Salary, request.Employee.DateOfBirth, request.Employee.HireDate,
            request.Employee.Gender, request.Employee.Email, addressResult.Value);

        if (employeeResult.IsFailure)
            return Result<EmployeeForListDto>.Failure(employeeResult.Error);

        Employee employee = employeeResult.Value;

        unitOfWork.EmployeeRepository.Create(employee);

        await unitOfWork.CommitAsync();

        return Result<EmployeeForListDto>.Success(mapper.Map<EmployeeForListDto>(employee));
    }
}

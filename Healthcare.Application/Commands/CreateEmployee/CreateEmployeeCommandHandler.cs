using AutoMapper;
using FluentValidation;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Application.Commands.CreateEmployee;
public sealed class CreateEmployeeCommandHandler(
    IEmployeeRepository employeeRepository,
    IMapper mapper
    ) : IRequestHandler<CreateEmployeeCommand, int>
{
    public async Task<int> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        await new CreateEmployeeCommandValidator()
            .ValidateAndThrowAsync(request.Employee, cancellationToken);

        var employee = mapper.Map<Employee>(request.Employee);

        employeeRepository.CreateEmployee(employee);

        await employeeRepository.SaveChangesAsync();

        return employee.Id;
    }
}

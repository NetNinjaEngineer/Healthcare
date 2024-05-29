using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Queries.GetEmployeeDetails;
public sealed class GetEmployeeDetailsQueryHandler(
    IEmployeeRepository employeeRepository
    ) : IRequestHandler<GetEmployeeDetailsQuery, Employee>
{
    public async Task<Employee> Handle(
        GetEmployeeDetailsQuery request,
        CancellationToken cancellationToken)
    {
        if (request.EmployeeId is not null)
        {
            var employee = await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId.Value);
            return employee is null
                ? throw new EmployeeNotFoundException($"Employee with ID: {request.EmployeeId} was not found !!!")
                : employee;
        }

        throw new IdParameterNullException($"{nameof(request.EmployeeId)} was null.");
    }
}

using Healthcare.Application.Interfaces;
using Healthcare.Domain;
using Healthcare.Domain.Entities;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Queries.GetEmployeeDetails;
public sealed class GetEmployeeDetailsQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetEmployeeDetailsQuery, Employee>
{
    public async Task<Employee> Handle(
        GetEmployeeDetailsQuery request,
        CancellationToken cancellationToken)
    {
        if (request.EmployeeId is not null)
        {
            var employee = await unitOfWork.EmployeeRepository.GetByIdAsync(request.EmployeeId.Value);
            return employee is null
                ? throw new EmployeeNotFoundException(ErrorMessages.EmployeeNotFound)
                : employee;
        }

        throw new IdParameterNullException($"{nameof(request.EmployeeId)} was null.");
    }
}

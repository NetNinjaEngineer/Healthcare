using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Application.Queries.GetAllEmployees;
public sealed class GetAllEmployeesQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
{
    public async Task<IEnumerable<Employee>> Handle(
        GetAllEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        return await unitOfWork.EmployeeRepository.GetAllAsync();
    }
}

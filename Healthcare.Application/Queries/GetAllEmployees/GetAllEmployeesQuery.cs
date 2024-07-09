using Healthcare.Application.DTOs.Employee;
using MediatR;

namespace Healthcare.Application.Queries.GetAllEmployees;
public sealed class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
{
}

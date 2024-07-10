using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Helpers;
using Healthcare.Domain.Specifications;
using MediatR;

namespace Healthcare.Application.Queries.GetAllEmployees;
public sealed class GetAllEmployeesQuery : IRequest<Pagination<EmployeeDto>>
{
    public EmployeeSpecParams EmployeeSpecParams { get; set; } = null!;
}

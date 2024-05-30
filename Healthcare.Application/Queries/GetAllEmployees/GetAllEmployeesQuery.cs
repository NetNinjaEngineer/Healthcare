using Healthcare.Application.DTOs;
using MediatR;

namespace Healthcare.Application.Queries.GetAllEmployees;
public sealed class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeForListDto>>
{
}

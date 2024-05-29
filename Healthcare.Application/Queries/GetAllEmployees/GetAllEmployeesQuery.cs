using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Application.Queries.GetAllEmployees;
public sealed class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
{
}

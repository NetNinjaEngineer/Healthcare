using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Application.Queries.GetEmployeeDetails;
public sealed class GetEmployeeDetailsQuery : IRequest<Employee>
{
    public int? EmployeeId { get; private set; }

    public GetEmployeeDetailsQuery(int? employeeId)
    {
        EmployeeId = employeeId;
    }
}

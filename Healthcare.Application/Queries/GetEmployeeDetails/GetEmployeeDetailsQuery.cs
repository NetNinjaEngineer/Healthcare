using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Application.Queries.GetEmployeeDetails;
public sealed class GetEmployeeDetailsQuery : IRequest<Employee>
{
    public string? EmployeeId { get; private set; }

    public GetEmployeeDetailsQuery(string? employeeId)
    {
        EmployeeId = employeeId;
    }
}

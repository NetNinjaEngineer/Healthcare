using Healthcare.Application.DTOs;
using MediatR;

namespace Healthcare.Application.Queries.GetEmployeeDetails;
public sealed class GetEmployeeDetailsQuery : IRequest<EmployeeForListDto>
{
    public string? EmployeeId { get; private set; }

    public GetEmployeeDetailsQuery(string? employeeId)
    {
        EmployeeId = employeeId;
    }
}

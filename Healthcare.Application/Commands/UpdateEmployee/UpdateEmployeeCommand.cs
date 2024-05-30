using Healthcare.Application.DTOs.Employee;
using MediatR;

namespace Healthcare.Application.Commands.UpdateEmployee;
public sealed class UpdateEmployeeCommand : IRequest<Unit>
{
    public string? EmployeeId { get; init; }
    public EmployeeForUpdateDto? UpdatedEmployee { get; set; }
}

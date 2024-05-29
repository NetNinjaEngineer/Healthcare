using Healthcare.Application.DTOs;
using MediatR;

namespace Healthcare.Application.Commands.PromoteEmployee;
public sealed class PromoteEmployeeCommand : IRequest<Unit>
{
    public int EmployeeId { get; set; }
    public PromoteEmployeeDto? PromoteEmployeeModel { get; set; }
}

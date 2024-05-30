using Healthcare.Application.DTOs.Employee;
using MediatR;

namespace Healthcare.Application.Commands.CreateEmployee;
public sealed class CreateEmployeeCommand : IRequest<EmployeeForListDto>
{
    public EmployeeForCreateDto Employee { get; set; } = null!;
}

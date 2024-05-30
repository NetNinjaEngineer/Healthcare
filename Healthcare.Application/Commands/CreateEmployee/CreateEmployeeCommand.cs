using Healthcare.Application.DTOs.Employee;
using MediatR;

namespace Healthcare.Application.Commands.CreateEmployee;
public sealed class CreateEmployeeCommand : IRequest<string>
{
    public EmployeeForCreateDto Employee { get; set; } = null!;
}

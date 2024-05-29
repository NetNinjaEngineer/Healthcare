using Healthcare.Application.DTOs;
using MediatR;

namespace Healthcare.Application.Commands.CreateEmployee;
public sealed class CreateEmployeeCommand : IRequest<int>
{
    public EmployeeForCreateDto Employee { get; set; } = null!;
}

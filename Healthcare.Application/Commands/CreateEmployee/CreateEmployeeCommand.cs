using Healthcare.Application.DTOs.Employee;
using Healthcare.Domain.Abstractions;
using MediatR;

namespace Healthcare.Application.Commands.CreateEmployee;
public sealed class CreateEmployeeCommand : IRequest<Result<EmployeeForListDto>>
{
    public EmployeeForCreateDto Employee { get; set; } = null!;
}

using Healthcare.Application.DTOs.Employee;
using MediatR;

namespace Healthcare.Application.Commands.CreateEmployeeCollection;
public sealed class CreateEmployeeCollectionCommand : IRequest<IEnumerable<EmployeeForListDto>>
{
    public IEnumerable<EmployeeForCreateDto> Employees { get; set; } = [];
}

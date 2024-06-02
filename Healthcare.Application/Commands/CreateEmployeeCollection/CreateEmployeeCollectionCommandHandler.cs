using AutoMapper;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Application.Commands.CreateEmployeeCollection;
public sealed class CreateEmployeeCollectionCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateEmployeeCollectionCommand, IEnumerable<EmployeeForListDto>>
{
    public async Task<IEnumerable<EmployeeForListDto>> Handle(
        CreateEmployeeCollectionCommand request,
        CancellationToken cancellationToken)
    {
        var employeeCollection = mapper.Map<IEnumerable<Employee>>(request.Employees);
        unitOfWork.EmployeeRepository.CreateCollection(employeeCollection);
        await unitOfWork.CommitAsync();
        return mapper.Map<IEnumerable<EmployeeForListDto>>(employeeCollection);
    }
}

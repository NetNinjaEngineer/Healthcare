using AutoMapper;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Specifications;
using MediatR;

namespace Healthcare.Application.Queries.GetAllEmployees;
public sealed class GetAllEmployeesQueryHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
{
    public async Task<IEnumerable<EmployeeDto>> Handle(
        GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetAllEmployeesWithScheduleSpecification();
        var employees = await unitOfWork.EmployeeRepository.GetAllWithSpecificationAsync(spec);
        return mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }
}

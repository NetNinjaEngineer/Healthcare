using AutoMapper;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Helpers;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Specifications;
using MediatR;

namespace Healthcare.Application.Queries.GetAllEmployees;
public sealed class GetAllEmployeesQueryHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllEmployeesQuery, Pagination<EmployeeDto>>
{
    public async Task<Pagination<EmployeeDto>> Handle(
        GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetAllEmployeesWithScheduleSpecification(request.EmployeeSpecParams);
        var employees = await unitOfWork.EmployeeRepository.GetAllWithSpecificationAsync(spec);
        var mappedEmployees = mapper.Map<IReadOnlyList<EmployeeDto>>(employees);
        var countEmployeeSpec = new EmployeeWithFilterationCountSpecification(request.EmployeeSpecParams);
        var totalCount = await unitOfWork.EmployeeRepository.GetCountWithSpecificationAsync(countEmployeeSpec);
        return new Pagination<EmployeeDto>(request.EmployeeSpecParams.PageNumber,
            request.EmployeeSpecParams.PageSize,
            totalCount,
            mappedEmployees);
    }
}

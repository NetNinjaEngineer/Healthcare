using AutoMapper;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Interfaces;
using MediatR;

namespace Healthcare.Application.Queries.GetAllEmployees;
public sealed class GetAllEmployeesQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeForListDto>>
{
    public async Task<IEnumerable<EmployeeForListDto>> Handle(
        GetAllEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<EmployeeForListDto>>(
            await unitOfWork.EmployeeRepository.GetAllAsync());
    }
}

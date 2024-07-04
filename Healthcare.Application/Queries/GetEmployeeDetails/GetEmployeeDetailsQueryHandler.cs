using AutoMapper;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Queries.GetEmployeeDetails;
public sealed class GetEmployeeDetailsQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<GetEmployeeDetailsQuery, EmployeeForListDto>
{
    public async Task<EmployeeForListDto> Handle(
        GetEmployeeDetailsQuery request,
        CancellationToken cancellationToken)
    {
        if (request.EmployeeId is null) throw new IdParameterNullException($"{nameof(request.EmployeeId)} was null.");
        var employee = await unitOfWork.EmployeeRepository.GetByIdAsync(request.EmployeeId);
        return employee is null
            ? throw new EmployeeNotFoundException("employee not founded.")
            : mapper.Map<EmployeeForListDto>(employee);

    }
}

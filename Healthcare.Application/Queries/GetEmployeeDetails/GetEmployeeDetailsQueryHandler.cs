using AutoMapper;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Interfaces;
using Healthcare.Domain;
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
        if (request.EmployeeId is not null)
        {
            var employee = await unitOfWork.EmployeeRepository.GetByIdAsync(request.EmployeeId);
            return employee is null
                ? throw new EmployeeNotFoundException(ErrorMessages.EmployeeNotFound)
                : mapper.Map<EmployeeForListDto>(employee);
        }

        throw new IdParameterNullException($"{nameof(request.EmployeeId)} was null.");
    }
}

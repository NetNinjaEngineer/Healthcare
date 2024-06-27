using AutoMapper;
using FluentValidation;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Application.Commands.CreateEmployee;
public sealed class CreateEmployeeCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<CreateEmployeeCommand, EmployeeForListDto>
{
    public async Task<EmployeeForListDto> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        await new CreateEmployeeCommandValidator()
            .ValidateAndThrowAsync(request.Employee, cancellationToken);

        var employee = mapper.Map<Employee>(request.Employee);
        unitOfWork.EmployeeRepository.Create(employee);

        await unitOfWork.CommitAsync();

        return mapper.Map<EmployeeForListDto>(employee);
    }
}

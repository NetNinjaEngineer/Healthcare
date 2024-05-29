using AutoMapper;
using FluentValidation;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Application.Commands.CreateEmployee;
public sealed class CreateEmployeeCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<CreateEmployeeCommand, int>
{
    public async Task<int> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        await new CreateEmployeeCommandValidator()
            .ValidateAndThrowAsync(request.Employee, cancellationToken);

        var employee = mapper.Map<Employee>(request.Employee);

        unitOfWork.EmployeeRepository.Create(employee);

        await unitOfWork.CommitAsync();

        return employee.Id;
    }
}

using AutoMapper;
using Healthcare.Application.Interfaces;
using Healthcare.Domain;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Commands.UpdateEmployee;
public sealed class UpdateEmployeeCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : IRequestHandler<UpdateEmployeeCommand, Unit>
{
    public async Task<Unit> Handle(UpdateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = await unitOfWork.EmployeeRepository
            .GetByIdAsync(request.EmployeeId)
            ?? throw new EmployeeNotFoundException(ErrorMessages.EmployeeNotFound);

        mapper.Map(request.UpdatedEmployee, employee);

        unitOfWork.EmployeeRepository.Update(employee);

        await unitOfWork.CommitAsync();

        return Unit.Value;

    }
}

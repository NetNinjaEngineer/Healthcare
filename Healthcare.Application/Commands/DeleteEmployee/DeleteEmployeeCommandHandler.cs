using Healthcare.Application.Interfaces;
using Healthcare.Domain;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Commands.DeleteEmployee;
public sealed class DeleteEmployeeCommandHandler(
        IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    public async Task<Unit> Handle(
        DeleteEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = await unitOfWork.EmployeeRepository.GetByIdAsync(request.Id)
            ?? throw new EmployeeNotFoundException(ErrorMessages.EmployeeNotFound);
        unitOfWork.EmployeeRepository.Delete(employee);
        await unitOfWork.CommitAsync();
        return Unit.Value;
    }
}

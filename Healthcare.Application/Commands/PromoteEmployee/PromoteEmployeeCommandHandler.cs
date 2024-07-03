using Healthcare.Application.Interfaces;
using Healthcare.Domain.Abstractions;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Commands.PromoteEmployee;
public sealed class PromoteEmployeeCommandHandler
    : IRequestHandler<PromoteEmployeeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public PromoteEmployeeCommandHandler(
        IUnitOfWork unitOfWork,
        IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(PromoteEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        if (request.EmployeeId == null)
            throw new IdParameterNullException($"{request.EmployeeId} is null.");
        var employee = await _unitOfWork.EmployeeRepository
            .GetByIdAsync(request.EmployeeId)
            ?? throw new EmployeeNotFoundException(DomainErrors.Employee.EmployeeNotFound);
        if (request.PromoteEmployeeModel is not null)
            employee.PromoteEmployee(request.PromoteEmployeeModel.SalaryIncrease);
        _unitOfWork.EmployeeRepository.Update(employee);
        await _unitOfWork.CommitAsync();
        return Unit.Value;
    }
}

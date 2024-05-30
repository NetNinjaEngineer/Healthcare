using Healthcare.Application.Commands.DeleteEmployee;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Application.Commands.DeletePatient;
public sealed class DeletePatientCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeletePatientCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var patients = _unitOfWork.Repository<Patient>().GetAllAsync();
    }
}

using Healthcare.Application.Commands.DeleteEmployee;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Commands.DeletePatient;
public sealed class DeletePatientCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        if (request.Id != null)
        {
            var patient = await unitOfWork.PatientRepository.GetByIdAsync(request.Id)
                          ?? throw new PatientNotFoundException($"Patient with id: {request.Id} was not found.");
            unitOfWork.PatientRepository.Delete(patient);
        }

        await unitOfWork.CommitAsync();
        return Unit.Value;
    }
}

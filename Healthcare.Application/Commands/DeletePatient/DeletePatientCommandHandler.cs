using Healthcare.Application.Interfaces;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Commands.DeletePatient;
public sealed class DeletePatientCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeletePatientCommand, Unit>
{
    public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        if (request.PatientId != null)
        {
            var patient = await unitOfWork.PatientRepository.GetByIdAsync(request.PatientId)
                          ?? throw new PatientNotFoundException($"Patient with id: {request.PatientId} was not found.");
            unitOfWork.PatientRepository.Delete(patient);
        }

        await unitOfWork.CommitAsync();
        return Unit.Value;
    }
}

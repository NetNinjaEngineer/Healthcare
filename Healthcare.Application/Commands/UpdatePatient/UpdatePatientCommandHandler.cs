using AutoMapper;
using Healthcare.Application.Interfaces;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Commands.UpdatePatient;
public sealed class UpdatePatientCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<UpdatePatientCommand, Unit>
{
    public async Task<Unit> Handle(
        UpdatePatientCommand request,
        CancellationToken cancellationToken)
    {
        var patientExists = unitOfWork.PatientRepository.CheckExists(request.PatientId);
        if (patientExists)
        {
            var patient = await unitOfWork.PatientRepository.GetByIdAsync(request.PatientId);
            mapper.Map(request.PatientForUpdate, patient);
            unitOfWork.PatientRepository.Update(patient);
            await unitOfWork.CommitAsync();
            return Unit.Value;
        }

        throw new PatientNotFoundException($"Patient with id: '{request.PatientId}' was not found.");
    }
}

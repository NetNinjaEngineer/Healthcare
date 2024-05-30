using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Queries.GetPatientDetails;
public sealed class GetPatientDetailsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetPatientDetailsQuery, Patient>
{
    public async Task<Patient> Handle(
        GetPatientDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var patient = await unitOfWork.PatientRepository.GetByIdAsync(request.PatientId)
                ?? throw new PatientNotFoundException($"Patient was not founded");
        return patient;
    }
}

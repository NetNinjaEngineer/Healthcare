using Healthcare.Application.DTOs.Patient;
using MediatR;

namespace Healthcare.Application.Queries.GetPatientDetails;

public sealed class GetPatientDetailsQuery(string patientId)
    : IRequest<PatientForListDto>
{
    public string PatientId { get; } = patientId;
}
using Healthcare.Application.DTOs.Patient;
using MediatR;

namespace Healthcare.Application.Queries.GetPatientDetails;

public sealed class GetPatientDetailsQuery(string patientId) : IRequest<PatientDto>
{
    public string PatientId { get; } = patientId;
}
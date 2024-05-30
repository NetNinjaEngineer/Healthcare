using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Application.Queries.GetPatientDetails;

public sealed class GetPatientDetailsQuery(string patientId)
    : IRequest<Patient>
{
    public string PatientId { get; } = patientId;
}
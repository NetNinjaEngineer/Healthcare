using Healthcare.Application.DTOs.Patient;
using MediatR;

namespace Healthcare.Application.Commands.UpdatePatient;
public sealed class UpdatePatientCommand : IRequest<Unit>
{
    public required string PatientId { get; set; }
    public required PatientForUpdateDto PatientForUpdate { get; set; }
}

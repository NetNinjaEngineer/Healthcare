using Healthcare.Application.DTOs.Patient;
using Healthcare.Domain.Entities;
using MediatR;

namespace Healthcare.Application.Commands.CreatePatient;
public sealed class CreatePatientCommand : IRequest<Patient>
{
    public PatientForCreateDto PatientForCreateDto { get; set; } = default!;
}

using MediatR;

namespace Healthcare.Application.Commands.DeletePatient;
public sealed class DeletePatientCommand : IRequest<Unit>
{
    public string PatientId { get; init; } = string.Empty;
}
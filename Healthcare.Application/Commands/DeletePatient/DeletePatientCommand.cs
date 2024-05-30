using MediatR;

namespace Healthcare.Application.Commands.DeletePatient;
public sealed class DeletePatientCommand : IRequest<Unit>
{
    public int PatientId { get; init; }
}
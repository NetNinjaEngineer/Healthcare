using Healthcare.Application.DTOs.Appointment;
using MediatR;

namespace Healthcare.Application.Commands.CancelAppointment;
public sealed class CancelAppointmentCommand : IRequest<AppointmentDto>
{
    public string AppointmentId { get; set; } = string.Empty;
}

using Healthcare.Application.DTOs.Appointment;
using Healthcare.Application.Responses;
using MediatR;

namespace Healthcare.Application.Commands.ScheduleAppointment;
public sealed class ScheduleAppointmentCommand : IRequest<ScheduleAppointmentResponse>
{
    public string PatientId { get; set; } = string.Empty;
    public string DepartmentId { get; set; } = string.Empty;
    public required AppointmentForCreateDto Appointment { get; set; }

}
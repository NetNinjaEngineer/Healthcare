using Healthcare.Application.Responses;
using MediatR;

namespace Healthcare.Application.Queries.GetPatientAppointmentSchedule;
public sealed class GetPatientAppointmentScheduleQuery : IRequest<ScheduleAppointmentResponse>
{
    public required string AppointmentId { get; set; }
    public required string PatientId { get; set; }
}

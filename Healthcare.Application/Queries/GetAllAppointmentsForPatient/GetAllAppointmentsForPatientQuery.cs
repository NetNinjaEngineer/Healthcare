using Healthcare.Application.Responses;
using MediatR;

namespace Healthcare.Application.Queries.GetAllAppointmentsForPatient;
public sealed class GetAllAppointmentsForPatientQuery : IRequest<IEnumerable<ScheduleAppointmentResponse>>
{
    public required string PatientId { get; set; }
}

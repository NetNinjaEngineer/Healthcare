using Healthcare.Application.Interfaces;
using Healthcare.Application.Responses;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Queries.GetAllAppointmentsForPatient;
public sealed class GetAllAppointmentsForPatientQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllAppointmentsForPatientQuery, IEnumerable<ScheduleAppointmentResponse>>
{
    public async Task<IEnumerable<ScheduleAppointmentResponse>> Handle(
        GetAllAppointmentsForPatientQuery request,
        CancellationToken cancellationToken)
    {
        var patientExists = unitOfWork.PatientRepository.CheckExists(request.PatientId);
        if (!patientExists)
            throw new PatientNotFoundException($"Patient not found.");
        var patientAppointments = unitOfWork.AppointmentRepository
            .GetAllAsync().Result.Where(x => x.PatientId == request.PatientId)
            .ToList();

        List<ScheduleAppointmentResponse> appointmentResponses = [];

        foreach (var patientAppointment in patientAppointments)
        {
            appointmentResponses.Add(new()
            {
                AppointmentId = patientAppointment.Id,
                DateOfAppointment = patientAppointment.AppointmentDate,
                TimeOfAppointment = patientAppointment.AppointmentTime,
                PatientId = patientAppointment.PatientId
            });
        }

        return appointmentResponses;

    }
}

using Healthcare.Application.Interfaces;
using Healthcare.Application.Responses;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Queries.GetPatientAppointmentSchedule;
public sealed class GetPatientAppointmentScheduleQueryHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<GetPatientAppointmentScheduleQuery, ScheduleAppointmentResponse>
{
    public async Task<ScheduleAppointmentResponse> Handle(
        GetPatientAppointmentScheduleQuery request,
        CancellationToken cancellationToken)
    {
        bool patientExists = unitOfWork.PatientRepository.CheckExists(request.PatientId);
        if (!patientExists)
            throw new PatientNotFoundException($"Patient not exists with id: {request.PatientId}");

        var patientAppointmentSchedule = (await unitOfWork.AppointmentRepository.GetAllAsync())
            .Where(appointment =>
                appointment.PatientId == request.PatientId &&
                appointment.Id == request.AppointmentId)
            .SingleOrDefault()
            ?? throw new AppointmentNotFoundException($"appointment with id '{request.AppointmentId}' not founded. ");

        var doctor = await unitOfWork.EmployeeRepository.GetByIdAsync(patientAppointmentSchedule.DoctorId);

        return new ScheduleAppointmentResponse
        {
            AppointmentId = request.AppointmentId,
            PatientId = patientAppointmentSchedule.PatientId,
            TimeOfAppointment = patientAppointmentSchedule.AppointmentTime,
            DateOfAppointment = patientAppointmentSchedule.AppointmentDate,

            Doctor = doctor.FirstName ?? ""
        };
    }
}

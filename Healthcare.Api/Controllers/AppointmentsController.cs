using Asp.Versioning;
using Healthcare.Application.Commands.CancelAppointment;
using Healthcare.Application.Commands.ScheduleAppointment;
using Healthcare.Application.DTOs.Appointment;
using Healthcare.Application.Queries.GetAllAppointmentsForPatient;
using Healthcare.Application.Queries.GetPatientAppointmentSchedule;
using Healthcare.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Api.Controllers;
[ApiVersion("1.0")]
[Route("api/patients/{patientId}/appointments")]
[ApiController]
public class AppointmentsController(IMediator mediator) : ControllerBase
{
    #region Schedule An Appointment
    [Route("schedule")]
    [HttpPost]
    public async Task<ActionResult<ScheduleAppointmentResponse>> ScheduleAppointment(
        string patientId, string departmentId, AppointmentForCreateDto appointment)
    {
        var result = await mediator.Send(new ScheduleAppointmentCommand()
        {
            PatientId = patientId,
            DepartmentId = departmentId,
            Appointment = appointment
        });

        return Accepted(result);

    }
    #endregion

    [Route("{appointmentId}")]
    [HttpGet]
    public async Task<ActionResult<ScheduleAppointmentResponse>> GetAppointmentForPatient(
        string appointmentId, string patientId)
        => Ok(await mediator.Send(new GetPatientAppointmentScheduleQuery
        {
            AppointmentId = appointmentId,
            PatientId = patientId
        }));


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ScheduleAppointmentResponse>>> GetAppointmentsForPatient(
       [FromRoute] string patientId)
       => Ok(await mediator.Send(new GetAllAppointmentsForPatientQuery
       {
           PatientId = patientId
       }));

    [Route("{appointmentId}/cancel")]
    [HttpPost]
    public async Task<ActionResult<AppointmentDto>> CancelAppointment([FromRoute] string appointmentId,
        [FromRoute] string patientId)
        => Ok(await mediator.Send(new CancelAppointmentCommand { PatientId = patientId, AppointmentId = appointmentId }));


}

using Healthcare.Application.Commands.ScheduleAppointment;
using Healthcare.Application.DTOs;
using Healthcare.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Api.Controllers;
[Route("api/patients/{patientId}/appointments")]
[ApiController]
public class AppointmentsController(IMediator mediator) : ControllerBase
{
    #region Schedule An Appointment
    [Route("schedule")]
    [HttpPost]
    public async Task<ActionResult<ScheduleAppointmentResponse>>
        ScheduleAppointment(string patientId, AppointmentForCreateDto appointment)
    {
        var result = await mediator.Send(new ScheduleAppointmentCommand()
        {
            PatientId = patientId,
            Appointment = appointment
        });

        return Accepted(result);

    }
    #endregion
}

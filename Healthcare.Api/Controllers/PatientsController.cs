using Healthcare.Application.Commands.CreatePatient;
using Healthcare.Application.Commands.DeletePatient;
using Healthcare.Application.DTOs;
using Healthcare.Application.Queries.GetPatientDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Api.Controllers;
[Route("api/patients")]
[ApiController]
public class PatientsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}", Name = "GetPatient")]
    public async Task<IActionResult> GetPatient(string id)
        => Ok(await mediator.Send(new GetPatientDetailsQuery(id)));

    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] PatientForCreateDto request)
    {
        var patientReturned = await mediator.Send(new CreatePatientCommand() { PatientForCreateDto = request });
        return CreatedAtRoute("GetPatient", new { id = patientReturned.Id }, patientReturned);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(string id)
    {
        await mediator.Send(new DeletePatientCommand { PatientId = id });
        return NoContent();
    }
}

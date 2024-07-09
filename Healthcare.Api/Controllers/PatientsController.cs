using Asp.Versioning;
using Healthcare.Application.Commands.CreatePatient;
using Healthcare.Application.Commands.DeletePatient;
using Healthcare.Application.Commands.UpdatePatient;
using Healthcare.Application.DTOs.Patient;
using Healthcare.Application.Queries.GetAllPatients;
using Healthcare.Application.Queries.GetPatientDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Api.Controllers;
[ApiVersion("1.0")]
[Route("api/patients")]
[ApiController]
public class PatientsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PatientDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
        => Ok(await mediator.Send(new GetAllPatientsQuery()));

    [HttpPost]
    [ProducesResponseType(typeof(PatientDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PatientDto>> CreatePatient([FromBody] PatientForCreateDto request)
    {
        var patientReturned = await mediator.Send(new CreatePatientCommand() { PatientForCreateDto = request });
        return CreatedAtRoute("GetPatient", new { id = patientReturned.Id }, patientReturned);
    }

    [HttpGet("{id}", Name = "GetPatient")]
    [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PatientDto>> GetPatient(string id)
        => Ok(await mediator.Send(new GetPatientDetailsQuery(id)));

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PatientDto>> UpdatePatient(string id, [FromBody] PatientForUpdateDto updatedPatient)
    {
        await mediator.Send(new UpdatePatientCommand { PatientId = id, PatientForUpdate = updatedPatient });
        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(PatientDto), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePatient(string id)
    {
        await mediator.Send(new DeletePatientCommand { PatientId = id });
        return NoContent();
    }
}

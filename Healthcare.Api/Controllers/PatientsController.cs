using Healthcare.Application.Commands.CreatePatient;
using Healthcare.Application.Commands.DeletePatient;
using Healthcare.Application.Commands.UpdatePatient;
using Healthcare.Application.DTOs.Patient;
using Healthcare.Application.Queries.GetAllPatients;
using Healthcare.Application.Queries.GetPatientDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Api.Controllers;
[Route("api/patients")]
[ApiController]
public class PatientsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PatientForListDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PatientForListDto>>> GetPatients()
        => Ok(await mediator.Send(new GetAllPatientsQuery()));

    [HttpPost]
    [ProducesResponseType(typeof(PatientForListDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PatientForListDto>> CreatePatient([FromBody] PatientForCreateDto request)
    {
        var patientReturned = await mediator.Send(new CreatePatientCommand() { PatientForCreateDto = request });
        return CreatedAtRoute("GetPatient", new { id = patientReturned.Id }, patientReturned);
    }

    [HttpGet("{id}", Name = "GetPatient")]
    [ProducesResponseType(typeof(PatientForListDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PatientForListDto>> GetPatient(string id)
        => Ok(await mediator.Send(new GetPatientDetailsQuery(id)));

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PatientForListDto>> UpdatePatient(string id, [FromBody] PatientForUpdateDto updatedPatient)
    {
        await mediator.Send(new UpdatePatientCommand { PatientId = id, PatientForUpdate = updatedPatient });
        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(PatientForListDto), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePatient(string id)
    {
        await mediator.Send(new DeletePatientCommand { PatientId = id });
        return NoContent();
    }
}

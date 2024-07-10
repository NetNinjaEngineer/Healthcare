using Asp.Versioning;
using Healthcare.Application.Commands.CreateEmployee;
using Healthcare.Application.Commands.CreateEmployeeCollection;
using Healthcare.Application.Commands.DeleteEmployee;
using Healthcare.Application.Commands.UpdateEmployee;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Filters;
using Healthcare.Application.Helpers;
using Healthcare.Application.Queries.GetAllEmployees;
using Healthcare.Application.Queries.GetEmployeeDetails;
using Healthcare.Domain.Abstractions;
using Healthcare.Domain.Entities;
using Healthcare.Domain.Specifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Api.Controllers;
[ApiVersion("1.0")]
[Route("api/employees")]
[ApiController]
public class EmployeesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateEmployee(EmployeeForCreateDto employee)
    {
        Result<EmployeeDto> employeeCreatedResult =
            await mediator.Send(new CreateEmployeeCommand { Employee = employee });

        if (employeeCreatedResult.IsFailure)
            return BadRequest(employeeCreatedResult.Error.ToString());

        return CreatedAtRoute("GetEmployee", new { id = employeeCreatedResult.Value.Id }, employeeCreatedResult.Value);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Pagination<EmployeeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<Pagination<EmployeeDto>>> GetEmployees([FromQuery] EmployeeSpecParams employeeSpecParams)
    {
        return Ok(await mediator.Send(new GetAllEmployeesQuery() { EmployeeSpecParams = employeeSpecParams }));
    }

    [HttpGet("{id}", Name = "GetEmployee")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<EmployeeDto>> GetEmployee(string id)
        => Ok(await mediator.Send(new GetEmployeeDetailsQuery(id)));

    [HttpPut("{id}")]
    [ServiceFilter<EmployeeExistsFilter>]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<IEnumerable<Employee>>> UpdateEmployee(string id,
        EmployeeForUpdateDto updatedEmployee)
    {
        await mediator.Send(new UpdateEmployeeCommand { EmployeeId = id, UpdatedEmployee = updatedEmployee });
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(string id)
    {
        await mediator.Send(new DeleteEmployeeCommand { Id = id });
        return NoContent();
    }

    //[Route("export")]
    //[HttpGet]
    //public async Task<IActionResult> Report(ExportType exportType)
    //{
    //    var result = (await mediator.Send(new EmployeeReportQuery(exportType))).Value;

    //    return File(result.file, result.mimeType, $"employees{result.fileExtension}");
    //}

    [Route("create-collection")]
    [HttpPost]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> CreateCollection(
        [FromBody] List<EmployeeForCreateDto> employees)
    {
        var employeeCollection = await mediator.Send(
            new CreateEmployeeCollectionCommand { Employees = employees });
        return Ok(employeeCollection);
    }

}

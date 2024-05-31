using Healthcare.Application.Commands.CreateEmployee;
using Healthcare.Application.Commands.DeleteEmployee;
using Healthcare.Application.Commands.PromoteEmployee;
using Healthcare.Application.Commands.UpdateEmployee;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Filters;
using Healthcare.Application.Queries.GetAllEmployees;
using Healthcare.Application.Queries.GetEmployeeDetails;
using Healthcare.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Api.Controllers;
[Route("api/employees")]
[ApiController]
public class EmployeesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(EmployeeForListDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateEmployee(EmployeeForCreateDto employee)
    {
        var employeeCreated = await mediator.Send(new CreateEmployeeCommand { Employee = employee });
        return CreatedAtRoute("GetEmployee", new { id = employeeCreated.Id }, employeeCreated);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<EmployeeForListDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<EmployeeForListDto>>> GetEmployees()
        => Ok(await mediator.Send(new GetAllEmployeesQuery()));

    [HttpGet("{id}", Name = "GetEmployee")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(EmployeeForListDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<EmployeeForListDto>> GetEmployee(string id)
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

    [Route("promote/{id}")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PromoteEmployee(string id, [FromBody] PromoteEmployeeDto body)
    {
        await mediator.Send(new PromoteEmployeeCommand() { EmployeeId = id, PromoteEmployeeModel = body });
        return NoContent();
    }

}

using Healthcare.Application.Commands.CreateEmployee;
using Healthcare.Application.Commands.DeleteEmployee;
using Healthcare.Application.Commands.PromoteEmployee;
using Healthcare.Application.Commands.UpdateEmployee;
using Healthcare.Application.DTOs;
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
    public async Task<IActionResult> CreateEmployee(EmployeeForCreateDto employee)
        => Ok(await mediator.Send(new CreateEmployeeCommand { Employee = employee }));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        => Ok(await mediator.Send(new GetAllEmployeesQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee(string id)
        => Ok(await mediator.Send(new GetEmployeeDetailsQuery(id)));

    [HttpPut("{id}")]
    public async Task<ActionResult<IEnumerable<Employee>>> UpdateEmployee(string id,
        EmployeeForUpdateDto updatedEmployee)
    {
        await mediator.Send(new UpdateEmployeeCommand { EmployeeId = id, UpdatedEmployee = updatedEmployee });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await mediator.Send(new DeleteEmployeeCommand { Id = id });
        return NoContent();
    }

    [Route("promote/{id}")]
    [HttpPut]
    public async Task<IActionResult> PromoteEmployee(string id, [FromBody] PromoteEmployeeDto body)
    {
        await mediator.Send(new PromoteEmployeeCommand() { EmployeeId = id, PromoteEmployeeModel = body });
        return NoContent();
    }

}

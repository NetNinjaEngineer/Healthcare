using Healthcare.Application.Commands.CreateEmployee;
using Healthcare.Application.Commands.DeleteEmployee;
using Healthcare.Application.Commands.UpdateEmployee;
using Healthcare.Application.DTOs;
using Healthcare.Application.Queries.GetAllEmployees;
using Healthcare.Application.Queries.GetEmployeeDetails;
using Healthcare.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Api.Controllers;
[Route("api/[controller]")]
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
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee(int id)
        => Ok(await mediator.Send(new GetEmployeeDetailsQuery(id)));

    [HttpPut("{id}")]
    public async Task<ActionResult<IEnumerable<Employee>>> UpdateEmployee(int id,
        EmployeeForUpdateDto updatedEmployee)
    {
        await mediator.Send(new UpdateEmployeeCommand { EmployeeId = id, UpdatedEmployee = updatedEmployee });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteEmployeeCommand { Id = id });
        return NoContent();
    }

}

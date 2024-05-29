using Healthcare.Application.Commands.CreateEmployee;
using Healthcare.Application.DTOs;
using Healthcare.Application.Queries.GetAllEmployees;
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

}

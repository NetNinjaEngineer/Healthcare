using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        return Ok(await _employeeRepository.GetEmployeesAsync());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employeeForUpdate)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
        if (employee is not null)
        {
            employee.FirstName = employeeForUpdate.FirstName;
            employee.LastName = employeeForUpdate.LastName;
            employee.Salary = employeeForUpdate.Salary;
            employee.HireDate = employeeForUpdate.HireDate;
            employee.DateOfBirth = employeeForUpdate.DateOfBirth;
            employee.DateOfBirth = employeeForUpdate.DateOfBirth;
            employee.JobTitle = employeeForUpdate.JobTitle;
            employee.Phone = employeeForUpdate.Phone;
            employee.Gender = employeeForUpdate.Gender;

            await _employeeRepository.SaveChangesAsync();

            return NoContent();
        }

        return NotFound();

    }

}

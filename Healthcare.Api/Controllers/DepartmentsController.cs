using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Api.Controllers;
[Route("api/departments/{departmentId}/employees")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetEmployeesInDepartment(
        [FromRoute] string departmentId)
    {
        return Ok("TODO: IN another time");
    }

    [Route("{employeeId}/assign")]
    [HttpPost]
    public async Task<IActionResult> AssignEmployeeToDepartment(
        [FromRoute] string departmentId,
        [FromRoute] string employeeId)
    {
        return Ok("TODO: IN another time");
    }
}

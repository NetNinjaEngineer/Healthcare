using Healthcare.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Healthcare.Application.Filters;

public class EmployeeExistsFilter(ILogger<EmployeeExistsFilter> logger, IUnitOfWork unitOfWork)
    : IActionFilter
{
    private readonly ILogger<EmployeeExistsFilter> _logger = logger;

    public void OnActionExecuted(ActionExecutedContext context)
    {
        return;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var employeeId = (string)context.ActionArguments["id"];
        var empExists = unitOfWork.EmployeeRepository.CheckExists(employeeId);
        if (empExists) return;
        context.Result = new NotFoundObjectResult($"employee with id: {employeeId} was not founded");
    }
}
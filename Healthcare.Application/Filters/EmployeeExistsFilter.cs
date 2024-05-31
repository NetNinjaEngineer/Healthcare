using Healthcare.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Healthcare.Application.Filters;

public class EmployeeExistsFilter : IActionFilter
{
    private readonly ILogger<EmployeeExistsFilter> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeExistsFilter(ILogger<EmployeeExistsFilter> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        return;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var employeeId = (string)context.ActionArguments["id"];
        var empExists = _unitOfWork.EmployeeRepository.CheckExists(employeeId);
        if (!empExists)
        {
            context.Result = new NotFoundObjectResult($"employee with id: {employeeId} was not founded");
            return;
        }
    }
}
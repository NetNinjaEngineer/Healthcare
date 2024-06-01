using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Strategies.DataExport.Models;
using MediatR;

namespace Healthcare.Application.Queries.GetAllEmployees;
public sealed class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeForListDto>>
{
    public ExportFormat ExportFormat { get; set; }
}

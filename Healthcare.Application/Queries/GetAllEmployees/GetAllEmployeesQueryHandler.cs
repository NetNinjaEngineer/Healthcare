using AutoMapper;
using Healthcare.Application.DTOs.Employee;
using Healthcare.Application.Helpers;
using Healthcare.Application.Interfaces;
using Healthcare.Application.Strategies.DataExport;
using Healthcare.Application.Strategies.DataExport.Models;
using MediatR;

namespace Healthcare.Application.Queries.GetAllEmployees;
public sealed class GetAllEmployeesQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ExportDataContext exportDataContext
    ) : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeForListDto>>
{
    public async Task<IEnumerable<EmployeeForListDto>> Handle(
        GetAllEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        var employees = mapper.Map<IEnumerable<EmployeeForListDto>>(
            await unitOfWork.EmployeeRepository.GetAllAsync());

        switch (request.ExportFormat)
        {
            case ExportFormat.PDF:
                exportDataContext.SetStrategy(new PDFExportStrategy());
                exportDataContext.ExportData(ExportFormat.PDF, Constants.EmployeeExportFileName, employees);
                break;
            case ExportFormat.CSV:
                exportDataContext.SetStrategy(new CSVExportStrategy());
                exportDataContext.ExportData(ExportFormat.CSV, Constants.EmployeeExportFileName, employees);
                break;
            case ExportFormat.NONE:
                break;
        }

        return employees;
    }
}

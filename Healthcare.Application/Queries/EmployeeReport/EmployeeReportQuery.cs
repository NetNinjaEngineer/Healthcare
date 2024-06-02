using Healthcare.Application.Strategies.Reporting;
using MediatR;

namespace Healthcare.Application.Queries.EmployeeReport;
public sealed class EmployeeReportQuery(ExportType exportType)
    : IRequest<(byte[] file, string mimeType, string fileExtension)>
{
    private readonly ExportType _exportType = exportType;
    public ExportType ExportType => _exportType;
}

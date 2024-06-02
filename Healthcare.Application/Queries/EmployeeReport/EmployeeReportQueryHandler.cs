using DinkToPdf.Contracts;
using Healthcare.Application.Helpers;
using Healthcare.Application.Interfaces;
using Healthcare.Application.Strategies.Reporting;
using Healthcare.Domain.Exceptions;
using MediatR;

namespace Healthcare.Application.Queries.EmployeeReport;
public sealed class EmployeeReportQueryHandler(
    IUnitOfWork unitOfWork,
    IConverter pdfConverter,
    ReportStrategyContext context)
    : IRequestHandler<EmployeeReportQuery, (byte[] file, string mimeType, string fileExtension)>
{
    public async Task<(byte[] file, string mimeType, string fileExtension)> Handle(
        EmployeeReportQuery request, CancellationToken cancellationToken)
    {
        var employees = await unitOfWork.EmployeeRepository.GetAllAsync();

        if (employees is not null)
        {
            byte[] fileBytes = default!;
            string mimeType = default!;
            string fileExtension = default!;
            switch (request.ExportType)
            {
                case ExportType.PDF:
                    context.SetReportStrategy(new PDFReportStrategy(pdfConverter));
                    fileBytes = context.Report(employees);
                    mimeType = Constants.PDFMimeType;
                    fileExtension = Constants.PDFExtension;
                    break;
                default:
                case ExportType.CSV:
                    context.SetReportStrategy(new CSVReportStrategy());
                    fileBytes = context.Report(employees);
                    mimeType = Constants.CSVMimeType;
                    fileExtension = Constants.CSVExtension;
                    break;
            }

            return (fileBytes, mimeType, fileExtension);
        }
        else
            throw new EmptyEmployeeCollection($"can not export an empty employee collection");
    }
}

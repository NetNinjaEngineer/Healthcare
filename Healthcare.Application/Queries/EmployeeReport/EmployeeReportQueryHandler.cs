//using DinkToPdf.Contracts;
//using Healthcare.Application.Helpers;
//using Healthcare.Application.Interfaces;
//using Healthcare.Application.Strategies.Reporting;
//using Healthcare.Domain.Entities;
//using Healthcare.Domain.Exceptions;
//using MediatR;

//namespace Healthcare.Application.Queries.EmployeeReport;
//public sealed class EmployeeReportQueryHandler(
//    IUnitOfWork unitOfWork,
//    IConverter pdfConverter,
//    ReportStrategyContext context)
//    : IRequestHandler<EmployeeReportQuery, Result<(byte[] file, string mimeType, string fileExtension)>>
//{

//    public async Task<Result<(byte[] file, string mimeType, string fileExtension)>> Handle(
//        EmployeeReportQuery request, CancellationToken cancellationToken)
//    {
//        return (await GetEmployeesAsync())
//            .OnSuccess(employees => GenerateReport(request, employees))
//            .OnFailure(error => throw new EmptyEmployeeCollection(error));
//    }

//    private async Task<Result<IEnumerable<Employee>>> GetEmployeesAsync()
//    {
//        var employees = await unitOfWork.EmployeeRepository.GetAllAsync();
//        return employees is not null
//            ? Result<IEnumerable<Employee>>.Success(employees)
//            : Result<IEnumerable<Employee>>.Failure("employees collection can not be null.");
//    }

//    private Result<(byte[] file, string mimeType, string fileExtension)> GenerateReport(
//        EmployeeReportQuery request, IEnumerable<Employee> employees)
//    {
//        byte[] fileBytes;
//        string mimeType;
//        string fileExtension;

//        switch (request.ExportType)
//        {
//            case ExportType.PDF:
//                context.SetReportStrategy(new PDFReportStrategy(pdfConverter));
//                fileBytes = context.Report(employees);
//                mimeType = Constants.PDFMimeType;
//                fileExtension = Constants.PDFExtension;
//                break;
//            default:
//            case ExportType.CSV:
//                context.SetReportStrategy(new CSVReportStrategy());
//                fileBytes = context.Report(employees);
//                mimeType = Constants.CSVMimeType;
//                fileExtension = Constants.CSVExtension;
//                break;
//        }

//        return Result<(byte[] file, string mimeType, string fileExtension)>.Success((fileBytes, mimeType, fileExtension));
//    }
//}

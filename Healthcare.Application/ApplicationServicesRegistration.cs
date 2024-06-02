using DinkToPdf;
using DinkToPdf.Contracts;
using Healthcare.Application.Filters;
using Healthcare.Application.Strategies.Reporting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Healthcare.Application;
public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(options =>
            options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<EmployeeExistsFilter>();
        services.AddScoped<IReportStrategy, PDFReportStrategy>();
        services.AddScoped<IReportStrategy, CSVReportStrategy>();
        services.AddScoped<ReportStrategyContext>();
        services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

        return services;
    }
}

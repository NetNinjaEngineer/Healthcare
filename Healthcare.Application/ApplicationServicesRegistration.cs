using Healthcare.Application.Filters;
using Healthcare.Application.Strategies.DataExport;
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
        services.AddScoped<IDataExportStrategy, CSVExportStrategy>();
        services.AddScoped<IDataExportStrategy, PDFExportStrategy>();
        services.AddScoped<ExportDataContext>();

        return services;
    }
}

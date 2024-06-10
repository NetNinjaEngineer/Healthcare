using Healthcare.Application.Interfaces;
using Healthcare.Domain.Interceptors;
using Healthcare.Infrastructure.Persistence;
using Healthcare.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Healthcare.Infrastructure;
public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .AddInterceptors([
                new SoftDeletableInterceptor(),
                new EmployeeLogsSaveChangesInterceptor()]));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

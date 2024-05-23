using Healthcare.Application.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Healthcare.Application;
internal static class MiddlewareExtensions
{
    public static IApplicationBuilder UseApplicationMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<LoggingMiddleware>();
        app.UseMiddleware<ErrorHandlingMiddleware>();

        return app;
    }
}

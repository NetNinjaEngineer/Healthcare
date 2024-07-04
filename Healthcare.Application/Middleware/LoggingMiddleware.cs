using Microsoft.AspNetCore.Http;

namespace Healthcare.Application.Middleware;
public class LoggingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        await next(context);
    }
}

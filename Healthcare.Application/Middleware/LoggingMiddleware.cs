using Microsoft.AspNetCore.Http;

namespace Healthcare.Application.Middleware;
internal class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log request details
        var request = context.Request;
        var requestBodyStream = new MemoryStream();
        await request.Body.CopyToAsync(requestBodyStream);
        requestBodyStream.Seek(0, SeekOrigin.Begin);
        var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();
        Console.WriteLine($"Request: {request.Method} {request.Path} {request.QueryString} - Body: {requestBodyText}");

        // Continue processing the request
        await _next(context);

        // Log response details
        var response = context.Response;
        var responseBodyStream = new MemoryStream();
        await response.Body.CopyToAsync(responseBodyStream);
        responseBodyStream.Seek(0, SeekOrigin.Begin);
        var responseBodyText = new StreamReader(responseBodyStream).ReadToEnd();
        Console.WriteLine($"Response: {response.StatusCode} - Body: {responseBodyText}");
    }
}

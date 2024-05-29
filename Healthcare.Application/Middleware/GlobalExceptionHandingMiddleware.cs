using FluentValidation;
using Healthcare.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Healthcare.Application.Middleware;
public class GlobalExceptionHandingMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(ex, context);
        }
    }

    private static async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        context.Response.ContentType = "application/json";
        var statusCode = HttpStatusCode.InternalServerError;
        JsonErrorResponse? jsonErrorResponse = null;

        switch (exception)
        {
            case ValidationException:
                var validationException = exception as ValidationException;
                var validationErrors = validationException!.Errors.Select(e => e.ErrorMessage)
                    .ToArray();
                statusCode = HttpStatusCode.UnprocessableEntity;
                jsonErrorResponse = new JsonErrorResponse("Validation Errors",
                    (int)statusCode, [.. validationErrors]);
                break;

            case EmployeeNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                jsonErrorResponse = new JsonErrorResponse(exception.Message, (int)statusCode, null);
                break;

            case IdParameterNullException:
                statusCode = HttpStatusCode.BadRequest;
                jsonErrorResponse = new JsonErrorResponse(exception.Message, (int)statusCode, null);
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                jsonErrorResponse = new JsonErrorResponse("Server error", (int)statusCode, null);
                break;
        }

        var serializedJsonErrorResponse = JsonSerializer.Serialize(jsonErrorResponse);
        await context.Response.WriteAsync(serializedJsonErrorResponse);
    }

    internal class JsonErrorResponse
    {
        private readonly string? _errorMessage;
        private readonly int? _statusCode;
        private readonly List<string>? _validationErrors;

        public JsonErrorResponse() { }

        public JsonErrorResponse(string? errorMessage, int? statusCode, List<string>? validationErrors)
        {
            _errorMessage = errorMessage;
            _statusCode = statusCode;
            _validationErrors = validationErrors;
        }
    }
}

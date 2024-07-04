using FluentValidation;
using Healthcare.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Healthcare.Application.Middleware;
public class GlobalExceptionHandingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
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
        JsonErrorResponse? jsonErrorResponse;

        switch (exception)
        {
            case ValidationException validationException:
                var validationErrors = validationException!.Errors.Select(e => e.ErrorMessage)
                    .ToArray();
                statusCode = HttpStatusCode.UnprocessableEntity;
                jsonErrorResponse = new JsonErrorResponse("Validation Errors",
                    (int)statusCode, [.. validationErrors]);
                break;

            case NotFoundException:
                statusCode = HttpStatusCode.NotFound;
                jsonErrorResponse = new JsonErrorResponse(exception.Message, (int)statusCode, null);
                break;

            case IdParameterNullException:
                statusCode = HttpStatusCode.BadRequest;
                jsonErrorResponse = new JsonErrorResponse(exception.Message, (int)statusCode, null);
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                jsonErrorResponse = new JsonErrorResponse($"Server error: {exception.Message}", (int)statusCode, null);
                break;
        }
        context.Response.StatusCode = (int)statusCode;
        var serializedResponse = JsonConvert.SerializeObject(jsonErrorResponse);
        await context.Response.WriteAsync(serializedResponse);
    }

    internal class JsonErrorResponse(string? errorMessage, int statusCode, List<string>? validationErrors)
    {
        public string? ErrorMessage { get; } = errorMessage;
        public int StatusCode { get; } = statusCode;
        public List<string>? ValidationErrors { get; } = validationErrors;

    }
}

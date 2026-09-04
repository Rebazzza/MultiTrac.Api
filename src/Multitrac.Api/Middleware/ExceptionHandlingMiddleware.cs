using System.Net;
using System.Text.Json;
using FluentValidation;
using Multitrac.Domain.Exceptions;

namespace Multitrac.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        var (statusCode, message) = exception switch
        {
            NotFoundException ex => (HttpStatusCode.NotFound, ex.Message),
            BadRequestException ex => (HttpStatusCode.BadRequest, ex.Message),
            ConflictException ex => (HttpStatusCode.Conflict, ex.Message),
            UnauthorizedException ex => (HttpStatusCode.Unauthorized, ex.Message),
            ForbiddenException ex => (HttpStatusCode.Forbidden, ex.Message),
            ValidationException ex => (HttpStatusCode.BadRequest, FormatValidationErrors(ex)),
            KeyNotFoundException ex => (HttpStatusCode.NotFound, ex.Message),
            ArgumentException ex => (HttpStatusCode.BadRequest, ex.Message),
            InvalidOperationException ex => (HttpStatusCode.Conflict, ex.Message),
            _ => (HttpStatusCode.InternalServerError, "An unexpected error occurred.")
        };

        if (statusCode == HttpStatusCode.InternalServerError)
        {
            _logger.LogError(exception, "Unhandled exception");
        }
        else
        {
            _logger.LogWarning(exception, "Handled exception: {Message}", exception.Message);
        }

        response.StatusCode = (int)statusCode;

        var result = JsonSerializer.Serialize(new
        {
            status = (int)statusCode,
            message,
            timestamp = DateTime.UtcNow
        }, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await response.WriteAsync(result);
    }

    private static string FormatValidationErrors(ValidationException exception)
    {
        var errors = exception.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToArray());

        return JsonSerializer.Serialize(errors, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }
}

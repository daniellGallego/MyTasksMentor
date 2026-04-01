using System.Net;
using System.Text.Json;
using MyTasksMentor.Domain.Exceptions;

namespace MyTasksMentor.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException ex)
        {
            await HandleException(context, ex.Message, HttpStatusCode.BadRequest);
        }
        catch (Exception)
        {
            await HandleException(context, "Internal server error", HttpStatusCode.InternalServerError);
        }
    }

    private static async Task HandleException(HttpContext context, string message, HttpStatusCode statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            message
        };

        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}
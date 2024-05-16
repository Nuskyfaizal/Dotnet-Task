using AppProgram.Helpers;
using FluentValidation;
using System.Text.Json;

namespace AppProgram.Middleware;
public class ValidationsExceptionsMiddleware
{
    private readonly RequestDelegate _request;

    public ValidationsExceptionsMiddleware(RequestDelegate request)
    {
        _request = request;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = 400;

            context.Response.ContentType = "application/json";

            var response = new AppException(ex.Message);

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
}
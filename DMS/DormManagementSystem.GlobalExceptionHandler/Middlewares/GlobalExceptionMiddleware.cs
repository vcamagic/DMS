using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using Microsoft.AspNetCore.Http;

namespace DormManagementSystem.GlobalExceptionHandler.Middlewares;

public class GlobalExceptionMiddleware
{
    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (HandleableException handleableException)
        {
            await HandleExceptionAsync(context, handleableException);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, HandleableException handleableException)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = handleableException.StatusCode;

        await context.Response.WriteAsync(handleableException.ErrorMessage);
    }

    private readonly RequestDelegate _next;
}

using DormManagementSystem.GlobalExceptionHandler.Middlewares;
namespace DormManagementSystem.Web.Api.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder ConfigureGlobalExceptionHandler(this IApplicationBuilder builder) =>
        builder.UseMiddleware<GlobalExceptionMiddleware>();
}

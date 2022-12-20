using DormManagementSystem.Web.Api.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DormManagementSystem.Web.Api.Extensions;

public static class AuthExtensions
{
    public static AuthenticationBuilder ConfigureAuthentication(this IServiceCollection services) =>
        services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

    public static IServiceCollection ConfigureAuthorization(this IServiceCollection services) =>
        services.AddAuthorization(builder =>
        {
            builder.AddPolicy(AppConstants.AppPolicies.WardenPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireClaim("Role", AppConstants.AppRoles.Warden, AppConstants.AppRoles.Administrator);
            });

            builder.AddPolicy(AppConstants.AppPolicies.AdministratorPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireClaim("Role", AppConstants.AppRoles.Administrator);
            });

            builder.AddPolicy(AppConstants.AppPolicies.MaidPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireClaim("Role", AppConstants.AppRoles.Maid);
            });

            builder.AddPolicy(AppConstants.AppPolicies.DoorkeeperPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireClaim("Role", AppConstants.AppRoles.Doorkeeper);
            });

            builder.AddPolicy(AppConstants.AppPolicies.StudentPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireClaim("Role", AppConstants.AppRoles.Student);
            });

            builder.AddPolicy(AppConstants.AppPolicies.JanitorPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireClaim("Role", AppConstants.AppRoles.Janitor);
            });
        });
}

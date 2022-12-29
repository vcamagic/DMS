using System.Security.Claims;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.Web.Api.Authorization;
using DormManagementSystem.Web.Api.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

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

            builder.AddPolicy(AppConstants.AppPolicies.OwnsAccountPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddRequirements(new OwnsAccountRequirement());
            });

            builder.AddPolicy(AppConstants.AppPolicies.WardenPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireClaim(ClaimTypes.Role, AppConstants.AppRoles.Warden, AppConstants.AppRoles.Administrator);
            });

            builder.AddPolicy(AppConstants.AppPolicies.AdministratorPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireClaim(ClaimTypes.Role, AppConstants.AppRoles.Administrator);
            });

            builder.AddPolicy(AppConstants.AppPolicies.MaidPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireClaim(ClaimTypes.Role, AppConstants.AppRoles.Maid, AppConstants.AppRoles.Administrator);
            });

            builder.AddPolicy(AppConstants.AppPolicies.DoorkeeperPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireClaim(ClaimTypes.Role, AppConstants.AppRoles.Doorkeeper, AppConstants.AppRoles.Administrator);
            });

            builder.AddPolicy(AppConstants.AppPolicies.StudentPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireClaim(ClaimTypes.Role, AppConstants.AppRoles.Student, AppConstants.AppRoles.Administrator);
            });

            builder.AddPolicy(AppConstants.AppPolicies.JanitorPolicy, opt =>
            {
                opt.RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                    .RequireClaim(ClaimTypes.Role, AppConstants.AppRoles.Janitor, AppConstants.AppRoles.Administrator);
            });
        });

    public static async void ConfigureApplicationRoles(this IApplicationBuilder app, IConfiguration configuration)
    {
        var roleNames = configuration.GetSection("ApplicationRoles").Get<IEnumerable<string>>();

        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            RoleManager<Role> roleManager = serviceScope.ServiceProvider.GetService<RoleManager<Role>>();

            foreach (string roleName in roleNames)
            {
                if (!roleManager.RoleExistsAsync(roleName).Result)
                {
                    Role role = new Role();
                    role.Name = roleName;
                    _ = await roleManager.CreateAsync(role);
                }
            }
        }
    }
}

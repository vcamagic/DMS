using System.Security.Claims;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using DormManagementSystem.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;


namespace DormManagementSystem.Web.Api.Authorization;

public class OwnsAccountPolicyHandler : AuthorizationHandler<OwnsAccountRequirement>
{
    public OwnsAccountPolicyHandler(IAccountsService accountsService, IHttpContextAccessor accessor)
    {
        _accountsService = accountsService;
        _accessor = accessor;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnsAccountRequirement requirement)
    {
        var routeParameter = _accessor.HttpContext.GetRouteValue("accountId") ??
            _accessor.HttpContext.GetRouteValue("id");

        if (routeParameter == null)
        {
            context.Fail();
            return;
        }

        var emailClaim = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        if (routeParameter == null || emailClaim == null || !Guid.TryParse(routeParameter as string, out var accountId))
        {
            context.Fail();
            return;
        }

        if (context.User.HasClaim(ClaimTypes.Role, AppConstants.AppRoles.Administrator))
        {
            context.Succeed(requirement);
            return;
        }

        var account = await _accountsService.GetAccount(emailClaim) ??
            throw new BadRequestException($"Account with email address {emailClaim} does not exist.");

        if (account.Id != accountId)
        {
            context.Fail();
            return;
        }

        context.Succeed(requirement);
    }

    private readonly IAccountsService _accountsService;
    private readonly IHttpContextAccessor _accessor;
}

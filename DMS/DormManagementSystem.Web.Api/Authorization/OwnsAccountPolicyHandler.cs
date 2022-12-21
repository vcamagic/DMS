using System;
using System.Linq;
using System.Threading.Tasks;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

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
        var routeParameter = _accessor.HttpContext.GetRouteValue("id") as string;
        var emailClaim = context.User.Claims.FirstOrDefault(x => x.Type == "Email")?.Value;

        if (routeParameter == null || emailClaim == null || !Guid.TryParse(routeParameter, out var accountId))
        {
            context.Fail();
            return;
        }

        if (context.User.HasClaim("Role", AppConstants.AppRoles.Administrator))
        {
            context.Succeed(requirement);
            return;
        }

        var account = await _accountsService.GetAccount(emailClaim);

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

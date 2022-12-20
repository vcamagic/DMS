using Microsoft.AspNetCore.Authorization;

namespace DormManagementSystem.Web.Api.Policies;

public class OwnsAccountPolicy : IAuthorizationHandler
{
    public Task HandleAsync(AuthorizationHandlerContext context)
    {
        var resource = context.Resource;
        var req = context.PendingRequirements.ToList();
        return Task.CompletedTask;
    }
}

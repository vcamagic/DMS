using Microsoft.AspNetCore.Authorization;

namespace DormManagementSystem.Web.Api.Authorization;

public class OwnsAccountRequirement : IAuthorizationRequirement
{
    public OwnsAccountRequirement()
    {        
    }
}

using Microsoft.AspNetCore.Identity;

namespace DormManagementSystem.DAL.Models.Models;

public class Role : IdentityRole<Guid>
{
    public Role()
    {
    }

    public Role(string roleName) : this()
    {
        Name = roleName;
    }
}

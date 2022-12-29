using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace DormManagementSystem.DAL.Models.Models;

public class Account : IdentityUser<Guid>
{
    [Required(ErrorMessage = $"{nameof(IsActive)} is required.")]
    public bool IsActive { get; set; }

    public override Guid Id
    {
        get { return base.Id; }
        set { base.Id = value; }
    }

    public User User { get; set; }
}

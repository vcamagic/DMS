using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.BLL.Services.DTOs;

public class RegisterAccountDTO
{
    [Required(ErrorMessage = $"{nameof(Email)} is required."), EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = $"{nameof(Password)} is required.")]
    public string Password { get; set; }
    [Required(ErrorMessage = $"{nameof(ConfirmPassword)} is required."), Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
    [Required(ErrorMessage = $"{nameof(Roles)} are required.")]
    public IEnumerable<Role> Roles { get; set; }
}

public enum Role
{
    [Description("Represents Administrator Role")]
    Administrator = 1,
    [Description("Represents Warden Role")]
    Warden = 2,
    [Description("Represents Maid Role")]
    Maid = 3,
    [Description("Represents Doorkeeper Role")]
    Doorkeeper = 4,
    [Description("Represents Janitor Role")]
    Janitor = 5,
    [Description("Represents Student Role")]
    Student = 6
}

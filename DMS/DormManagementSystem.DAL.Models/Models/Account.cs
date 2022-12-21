using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.DAL.Models.Models;

public class Account
{
    public Account()
    {
        Id = Guid.NewGuid();
    }
    [Key, Required(ErrorMessage = $"{nameof(Id)} is required.")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = $"{nameof(Email)} is required."), MaxLength(50, ErrorMessage = $"{nameof(Email)} max length is 50 characters."), EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = $"{nameof(PasswordHash)} is required.")]
    public string PasswordHash { get; set; }
    [Required(ErrorMessage = $"{nameof(IsActive)} is required.")]  
    public bool IsActive { get; set; }

    public User User { get; set; }
    public ICollection<Claim> Claims { get; set; }
}

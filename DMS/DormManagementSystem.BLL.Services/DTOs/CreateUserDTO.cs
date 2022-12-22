using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.BLL.Services.DTOs;

public class CreateUserDTO
{
    [Required(ErrorMessage = $"{nameof(FirstName)} is required.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = $"{nameof(LastName)} is required.")] 
    public string LastName { get; set; }
    [Required(ErrorMessage = $"{nameof(DateOfBirth)} is required.")] 
    public DateTime DateOfBirth  { get; set; }
    public string Address { get; set; }
    [Required(ErrorMessage = $"{nameof(JMBG)} is required.")] 
    public string JMBG { get; set; }
    [Required(ErrorMessage = $"{nameof(AccountId)} is required.")] 
    public Guid AccountId { get; set; }
}
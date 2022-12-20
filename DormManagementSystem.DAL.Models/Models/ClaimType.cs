using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.DAL.Models.Models;

public class ClaimType
{
    [Key, Required(ErrorMessage = $"{nameof(Id)} is required.")]    
    public Guid Id { get; set; }
    [Required(ErrorMessage = $"{nameof(Name)} is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = $"{nameof(Value)} is required.")] 
    public string Value { get; set; }
}

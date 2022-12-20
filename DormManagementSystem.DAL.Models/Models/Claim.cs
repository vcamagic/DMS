using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.DAL.Models.Models;

public class Claim
{
    public Claim()
    {
        Id = Guid.NewGuid();      
    }
    public Claim(string name, string value)
    {
        Id = Guid.NewGuid();
        Name = name;
        Value = value;
    }

    [Key, Required(ErrorMessage = $"{nameof(Id)} is required.")]    
    public Guid Id { get; set; }
    [Required(ErrorMessage = $"{nameof(Name)} is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = $"{nameof(Value)} is required.")] 
    public string Value { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; }
}

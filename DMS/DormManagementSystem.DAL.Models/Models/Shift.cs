using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.DAL.Models.Models;

public class Shift
{
    public Shift()
    {
        Id = Guid.NewGuid();
    }

    [Required(ErrorMessage = $"{nameof(Id)} is required.")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = $"{nameof(Start)} is required.")]
    public DateTime Start { get; set; }
    [Required(ErrorMessage = $"{nameof(End)} is required.")]
    public DateTime End { get; set; }

    
    public ICollection<Employee> Employees { get; set; }
}

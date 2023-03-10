using System.ComponentModel.DataAnnotations.Schema;

namespace DormManagementSystem.DAL.Models.Models;

[Table("Janitors")]
public class Janitor : Employee
{
    public ICollection<Malfunction> Malfunctions { get; set; }
}

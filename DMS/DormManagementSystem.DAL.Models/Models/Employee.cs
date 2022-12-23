using System.ComponentModel.DataAnnotations.Schema;

namespace DormManagementSystem.DAL.Models.Models;

[Table("Employees")]
public class Employee : User
{
    public ICollection<Shift> Shifts { get; set; }
}

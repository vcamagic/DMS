using System.ComponentModel.DataAnnotations.Schema;

namespace DormManagementSystem.DAL.Models.Models;

[Table("Maids")]
public class Maid : Employee
{
    public Guid? FloorId { get; set; }
    public Floor Floor { get; set; }
}

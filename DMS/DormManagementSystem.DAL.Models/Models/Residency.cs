using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DormManagementSystem.DAL.Models.Models;

[Table("Residencies")]
public class Residency : Room
{
    [Required, Range(0, 10)]
    public int Capacity { get; set; }

    public ICollection<Student> Students { get; set; }
}
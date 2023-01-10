using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DormManagementSystem.DAL.Models.Models;

[Table("Laundries")]
public class Laundry : Room
{
    [Required]
    public int Capacity { get; set; }
}
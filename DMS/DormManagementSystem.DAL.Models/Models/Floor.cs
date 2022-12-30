using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.DAL.Models.Models;

public class Floor
{
    [Key, Required]
    public Guid Id { get; set; }
    [Range(0, 10)]
    public int Level { get; set; }

    public Maid Maid { get; set; }
    public ICollection<Room> Rooms { get; set; }
}
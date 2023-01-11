using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.DAL.Models.Models;

public class Room
{
    [Key, Required]
    public Guid Id { get; set; }
    [MaxLength(3)]
    public string RoomNumber { get; set; }
    [Required]
    public Guid FloorId { get; set; }
    public Floor Floor { get; set; }

    public ICollection<Malfunction> Malfunctions { get; set; }
}
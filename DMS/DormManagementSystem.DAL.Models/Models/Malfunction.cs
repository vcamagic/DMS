using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.DAL.Models.Models;

public class Malfunction
{
    public Malfunction()
    {
        Id = Guid.NewGuid();
    }
    [Key, Required]
    public Guid Id { get; set; }
    [MaxLength(250)]
    public string Description { get; set; }
    [Required, Range(0, 5)]
    public int Priority { get; set; }
    public DateTime? ExpectedFixTime { get; set; }
    public DateTime? ActualFixTime { get; set; }
    [Required]
    public bool IsFixed { get; set; }

    [Required]
    public Guid StudentId { get; set; }
    public Student Student { get; set; }

    [Required]
    public Guid RoomId { get; set; }
    public Room Room { get; set; }

    public ICollection<Janitor> Janitors { get; set; }
}

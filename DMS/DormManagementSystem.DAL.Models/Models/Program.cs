using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.DAL.Models.Models;

public class Program
{
    [Key, Required] public Guid Id { get; set; }
    [MaxLength(50)] public string Name { get; set; }
    [Required, Range(0, int.MaxValue)] public int Temperature { get; set; }
    [Required, Range(0, float.MaxValue)] public float Duration { get; set; }

    [Required] public Guid WashingMachineId { get; set; }
    public WashingMachine WashingMachine { get; set; }

    public ICollection<Reservation> Reservations { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.DAL.Models.Models;

public class WashingMachine
{
    [Key, Required] public Guid Id { get; set; }
    [Required, Range(0, 20)] public int KgCapacity { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }

    [Required] public Guid LaundryId { get; set; }
    public Laundry Laundry { get; set; }

    public ICollection<Program> Programs { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
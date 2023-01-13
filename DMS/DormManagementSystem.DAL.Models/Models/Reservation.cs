using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.DAL.Models.Models;

public class Reservation
{
    [Key, Required] public Guid Id { get; set; }
    [Required] public DateTime From { get; set; }
    [Required] public DateTime To { get; set; }

    [Required] public Guid ProgramId { get; set; }
    public Program Program { get; set; }

    [Required] public Guid WashingMachineId { get; set; }
    public WashingMachine WashingMachine { get; set; }

    [Required] public Guid StudentId { get; set; }
    public Student Student { get; set; }
}
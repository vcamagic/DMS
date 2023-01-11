using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.BLL.Services.DTOs;

public class RequestWashingMachineDTO
{
    [Required(ErrorMessage = $"{nameof(KgCapacity)} is required"), Range(0, 20, ErrorMessage = $"{nameof(KgCapacity)} must be between 0 and 20 kg")]
    public int KgCapacity { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }

    [Required(ErrorMessage = $"{nameof(LaundryId)} is required")]
    public Guid LaundryId { get; set; }
}
using System.ComponentModel.DataAnnotations;
using DormManagementSystem.BLL.Services.CustomValidationAttributes;

namespace DormManagementSystem.BLL.Services.DTOs;

public class CreateResidenciesDTO
{
    [DistinctPropertyValue(nameof(CreateResidencyDTO.RoomNumber))]
    [MaxLength(50, ErrorMessage = "There can only be 50 residencies per request.")]
    public IEnumerable<CreateResidencyDTO> Residencies { get; set; }
}

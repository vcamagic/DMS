using DormManagementSystem.BLL.Services.CustomValidationAttributes;

namespace DormManagementSystem.BLL.Services.DTOs;
public class CreateFloorsDTO
{
    [DistinctPropertyValue(nameof(CreateFloorDTO.Level))]
    public IEnumerable<CreateFloorDTO> FloorDTOs { get; set; }
}
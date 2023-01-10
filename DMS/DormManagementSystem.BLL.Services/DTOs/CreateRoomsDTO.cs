using DormManagementSystem.BLL.Services.CustomValidationAttributes;

namespace DormManagementSystem.BLL.Services.DTOs;

public class CreateRoomsDTO
{
    [DistinctPropertyValue(nameof(RoomDTO.RoomNumber))]
    public IEnumerable<RoomDTO> Rooms { get; set; }
}
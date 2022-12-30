using DormManagementSystem.BLL.Services.DTOs;

namespace DormManagementSystem.BLL.Services.Interfaces;
public interface IDormStructureService
{
    Task CreateFloors(IEnumerable<CreateFloorDTO> floorDTOs);
    Task CreateFloor(CreateFloorDTO floorDTOs);
}
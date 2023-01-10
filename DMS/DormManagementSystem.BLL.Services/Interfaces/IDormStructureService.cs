using DormManagementSystem.BLL.Services.DTOs;

namespace DormManagementSystem.BLL.Services.Interfaces;
public interface IDormStructureService
{
    Task<IReadOnlyList<FloorDTO>> GetDormStructure();
    Task CreateFloors(IEnumerable<CreateFloorDTO> floorDTOs);
    Task CreateFloor(CreateFloorDTO floorDTOs);
    Task AddResidenciesToFloor(Guid floorId, CreateResidenciesDTO residenciesDTO);
    Task AddLaundryToFloor(Guid floorId, CreateLaundryDTO createLaundryDTO);
    Task AddEntertainmentToFloor(Guid floorId, CreateEntertainmentDTO createEntertainmentDTO);
    Task DeleteRoom(Guid roomId);
}
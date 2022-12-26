using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IDoorkeepersService
{
    Task<DoorkeeperDTO> GetDoorkeeper(Guid id);
    Task<Page<DoorkeeperDTO>> GetDoorkeepers(PaginationDTO paginationDTO);
    Task<DoorkeeperDTO> CreateDoorkeeper(CreateDoorkeeperDTO createDoorkeeperDTO);
}

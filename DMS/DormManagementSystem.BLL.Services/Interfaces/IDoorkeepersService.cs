using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IDoorkeepersService : IServiceBase<Doorkeeper>
{
    Task<DoorkeeperDTO> CreateDoorkeeper(CreateDoorkeeperDTO createDoorkeeperDTO);
}

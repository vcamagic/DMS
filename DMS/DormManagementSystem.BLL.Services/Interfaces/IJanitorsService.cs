using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IJanitorsService : IServiceBase<Janitor>
{
    Task<JanitorDTO> CreateJanitor(CreateJanitorDTO createJanitorDTO);
}

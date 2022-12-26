using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IJanitorsService
{
    Task<JanitorDTO> CreateJanitor(CreateJanitorDTO createJanitorDTO);
}

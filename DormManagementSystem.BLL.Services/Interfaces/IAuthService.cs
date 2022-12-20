using DormManagementSystem.BLL.Services.DTOs;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IAuthService
{
    public Task RegisterUser(RegisterAccountDTO registerAccountDTO);
}

using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IAuthService
{
    public Task<Account> RegisterAccount(RegisterAccountDTO registerAccountDTO);
    public Task Login(LoginDTO loginDTO);
}

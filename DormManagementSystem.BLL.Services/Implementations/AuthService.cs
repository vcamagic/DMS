using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace DormManagementSystem.BLL.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IPasswordHasher<Account> _passwordHasher;

    public AuthService(IPasswordHasher<Account> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }
    public Task RegisterUser(RegisterAccountDTO registerAccountDTO)
    {
        
        
        throw new NotImplementedException();
    }
}

using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace DormManagementSystem.BLL.Services.Implementations;

public class AuthService : IAuthService
{
    public AuthService(
        IPasswordHasher<Account> passwordHasher,
        IRepositoryManager repositoryManager,
        IHttpContextAccessor httpContextAccessor,
        IAccountsService accountsService)
    {
        _passwordHasher = passwordHasher;
        _repositoryManager = repositoryManager;
        _httpContextAccessor = httpContextAccessor;
        _accountsService = accountsService;
    }

    public async Task<AccountDTO> RegisterAccount(RegisterAccountDTO registerAccountDTO)
    {
        
        var existingAccount = await _accountsService.GetAccount(registerAccountDTO.Email);

        if (existingAccount != null)
        {
            throw new BadRequestException($"Account with email {registerAccountDTO.Email} already exists.");
        }

        var createAccount = new CreateAccountDTO
        {
            Email = registerAccountDTO.Email,
            PasswordHash = _passwordHasher.HashPassword(new Account(), registerAccountDTO.Password),
            Claims = ConvertRolesToClaims(registerAccountDTO.Roles),
            IsActive = false
        };

        return await _accountsService.CreateAccount(createAccount);
    }

    public async Task Login(LoginDTO loginDTO)
    {
        var account = await _repositoryManager
            .AccountRepository
            .FindByCondition(x => x.Email == loginDTO.Email, false)
            .Include(x => x.Claims)
            .FirstOrDefaultAsync();

        if (account == null)
        {
            throw new BadRequestException("Bad credentials.");
        }

        if (account.IsActive == false)
        {
            throw new BadRequestException($"Account with email address {account.Email} is not activated.");
        }

        var result = _passwordHasher.VerifyHashedPassword(account, account.PasswordHash, loginDTO.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            throw new BadRequestException("Bad credentials");
        }

        await _httpContextAccessor
            .HttpContext
            .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, UserHelper.Convert(account));
    }

    private static IReadOnlyList<ClaimDTO> ConvertRolesToClaims(IEnumerable<Role> roles) =>
        roles.Select(x =>
        {
            return x switch
            {
                Role.Administrator => new ClaimDTO { Name = "Role", Value = "Administrator"},
                Role.Warden => new ClaimDTO { Name = "Role", Value = "Warden"},
                Role.Maid => new ClaimDTO { Name = "Role", Value = "Maid"},
                Role.Doorkeeper => new ClaimDTO { Name = "Role", Value = "Doorkeeper"},
                Role.Janitor => new ClaimDTO { Name = "Role", Value = "Janitor"},
                Role.Student => new ClaimDTO { Name = "Role", Value = "Student"},
                _ => new ClaimDTO()
            };
        }).ToList();

    private readonly IPasswordHasher<Account> _passwordHasher;
    private readonly IRepositoryManager _repositoryManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAccountsService _accountsService;
}

public static class UserHelper
{
    public static System.Security.Claims.ClaimsPrincipal Convert(Account account)
    {
        var claims = account.Claims.Select(x => new System.Security.Claims.Claim(x.Name, x.Value)).ToList();
        claims.Add(new System.Security.Claims.Claim("Email", account.Email));

        var identity = new System.Security.Claims.ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        return new System.Security.Claims.ClaimsPrincipal(identity);
    }
}

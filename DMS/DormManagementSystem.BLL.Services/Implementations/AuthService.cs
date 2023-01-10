using System.Security.Claims;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
namespace DormManagementSystem.BLL.Services.Implementations;

public class AuthService : IAuthService
{
    public AuthService(
        SignInManager<Account> signInManager,
        UserManager<Account> userManager,
        RoleManager<DAL.Models.Models.Role> roleManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<AccountDTO> RegisterAccount(RegisterAccountDTO registerAccountDTO)
    {
        var existingAccount = await _userManager.FindByEmailAsync(registerAccountDTO.Email);

        if (existingAccount != null)
        {
            throw new BadRequestException($"Account with email {registerAccountDTO.Email} already exists.");
        }

        var account = new Account
        {
            Email = registerAccountDTO.Email,
            UserName = registerAccountDTO.Email,
        };

        var result = await _userManager.CreateAsync(account, registerAccountDTO.Password);

        if (!result.Succeeded)
        {
            throw new BadRequestException($"Error while creating new account.");
        }

        foreach (var role in registerAccountDTO.Roles)
        {
            await _userManager.AddToRoleAsync(account, ConvertToRole(role));
        }

        return new AccountDTO
        {
            Id = account.Id,
            Email = account.Email,
            IsActive = false,
        };
    }

    public async Task Login(LoginDTO loginDTO)
    {
        var account = await _userManager.FindByEmailAsync(loginDTO.Email) ??
            throw new BadRequestException("Bad credentials.");

        if (account.IsActive == false)
        {
            throw new BadRequestException($"Account with email address {account.Email} is not activated.");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(account, loginDTO.Password, false);

        if (result == SignInResult.Failed)
        {
            throw new BadRequestException("Bad credentials.");
        }

        await _signInManager.SignInAsync(
        account,
        new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTime.Now.AddMinutes(30),
            AllowRefresh = true,
        });
    }

    public async Task RefreshCookie(ClaimsPrincipal user)
    {
        var identifierClaim = user.FindFirst(ClaimTypes.NameIdentifier) ??
            throw new BadRequestException($"User object has no identifier claim.");

        if (!Guid.TryParse(identifierClaim.Value, out var idGuid))
        {
            throw new BadRequestException($"User object identifier claim is not a GUID.");
        }

        var account = await _userManager.FindByIdAsync(idGuid.ToString()) ??
            throw new NotFoundException($"Account with id {idGuid} does not exist.");

        await _signInManager.RefreshSignInAsync(account);
    }

    private static string ConvertToRole(DTOs.Role roles) =>
        roles switch
        {
            DTOs.Role.Administrator => "Administrator",
            DTOs.Role.Doorkeeper => "Doorkeeper",
            DTOs.Role.Janitor => "Janitor",
            DTOs.Role.Maid => "Maid",
            DTOs.Role.Warden => "Warden",
            DTOs.Role.Student => "Student",
            _ => ""
        };

    private readonly SignInManager<Account> _signInManager;
    private readonly UserManager<Account> _userManager;
    private readonly RoleManager<DAL.Models.Models.Role> _roleManager;
}

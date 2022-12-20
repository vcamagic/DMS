using System.Security.Claims;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormManagementSystem.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("/register-account")]
    public async Task<IActionResult> RegisterAccount([FromBody] RegisterAccountDTO registerAccountDTO) 
    {
        var account = await _authService.RegisterAccount(registerAccountDTO);
        return Ok();
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        await _authService.Login(loginDTO);
        return Ok();
    }
}
 
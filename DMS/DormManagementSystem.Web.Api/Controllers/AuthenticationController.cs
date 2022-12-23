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
    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("/register-account")]
    public async Task<ActionResult<AccountDTO>> RegisterAccount([FromBody] RegisterAccountDTO registerAccountDTO) 
    {
        var accountDTO  = await _authService.RegisterAccount(registerAccountDTO);
        return Ok(accountDTO);
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        await _authService.Login(loginDTO);
        return Ok();
    }

    private readonly IAuthService _authService;
}
 
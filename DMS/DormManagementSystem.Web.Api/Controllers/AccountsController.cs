using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormManagementSystem.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountsController : ControllerBase
{
    public AccountsController(IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }

    [HttpGet]
    [Authorize(Policy = AppConstants.AppPolicies.AdministratorPolicy)]
    public async Task<ActionResult<IReadOnlyList<AccountDTO>>> Get([FromQuery]PaginationDTO paginationDTO)
    {
        var accounts = await _accountsService.GetAccounts(paginationDTO);
        return Ok(accounts);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = AppConstants.AppPolicies.OwnsAccountPolicy)]
    public async Task<ActionResult<AccountDTO>> Get([FromRoute]Guid id)
    {
        var account = await _accountsService.GetAccount(id);
        return Ok(account);
    }

    [Authorize(Policy = AppConstants.AppPolicies.AdministratorPolicy)]
    [HttpPut("activate/{id}")]
    public async Task<IActionResult> ActivateAccount([FromRoute]Guid id)
    {
        await _accountsService.ActivateAccount(id);
        return Ok();
    }

    private readonly IAccountsService _accountsService;    
}

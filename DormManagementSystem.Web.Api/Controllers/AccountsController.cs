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

    [Authorize(Policy = AppConstants.AppPolicies.AdministratorPolicy)]
    public async Task<ActionResult<IReadOnlyList<AccountDTO>>> Get([FromQuery]PaginationDTO paginationDTO)
    {
        var accounts = await _accountsService.GetAccounts(paginationDTO);

        return Ok(accounts);
    }

    [Authorize(Policy = AppConstants.AppPolicies.AdministratorPolicy)]
    [HttpPut("activate/{accountId}")]
    public async Task<IActionResult> ActivateAccount([FromRoute]Guid accountId)
    {
        await _accountsService.ActivateAccount(accountId);
        return Ok();
    }

    private readonly IAccountsService _accountsService;    
}

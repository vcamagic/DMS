using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormManagementSystem.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("student/{id}")]
    public async Task<ActionResult<StudentDTO>> GetStudent([FromRoute] Guid id)
    {
        var student = await _usersService.GetStudent(id);
        return Ok(student);
    }

    [HttpGet("warden/{id}")]
    public async Task<ActionResult<StudentDTO>> GetWarden([FromRoute] Guid id)
    {
        var warden = await _usersService.GetWarden(id);
        return Ok(warden);
    }

    [HttpGet("janitor/{id}")]
    public async Task<ActionResult<StudentDTO>> GetJanitor([FromRoute] Guid id)
    {
        var janitor = await _usersService.GetJanitor(id);
        return Ok(janitor);
    }

    [HttpGet("maid/{id}")]
    public async Task<ActionResult<StudentDTO>> GetMaid([FromRoute] Guid id)
    {
        var maid = await _usersService.GetMaid(id);
        return Ok(maid);
    }

    [HttpGet("doorkeeper/{id}")]
    public async Task<ActionResult<StudentDTO>> GetDoorkeeper([FromRoute] Guid id)
    {
        var doorkeeper = await _usersService.GetDoorkeeper(id);
        return Ok(doorkeeper);
    }

    [HttpPost("warden")]
    [Authorize(Policy = AppConstants.AppPolicies.WardenPolicy)]
    public async Task<IActionResult> CreateWarden([FromBody] CreateWardenDTO createWardenDTO)
    {
        var warden = await _usersService.CreateWarden(createWardenDTO);
        return CreatedAtAction(nameof(GetWarden), new { id = warden.Id }, warden);
    }

    [HttpPost("janitor")]
    [Authorize(Policy = AppConstants.AppPolicies.JanitorPolicy)]
    public async Task<IActionResult> CreateJanitor([FromBody] CreateJanitorDTO createJanitorDTO)
    {
        var janitor = await _usersService.CreateJanitor(createJanitorDTO);
        return CreatedAtAction(nameof(GetJanitor), new { id = janitor.Id }, janitor);
    }

    [HttpPost("maid")]
    [Authorize(Policy = AppConstants.AppPolicies.MaidPolicy)]
    public async Task<IActionResult> CreateMaid([FromBody] CreateMaidDTO createMaidDTO)
    {
        var maid = await _usersService.CreateMaid(createMaidDTO);
        return CreatedAtAction(nameof(GetMaid), new { id = maid.Id }, maid);
    }

    [HttpPost("doorkeeper")]
    [Authorize(Policy = AppConstants.AppPolicies.DoorkeeperPolicy)]
    public async Task<IActionResult> CreateDoorkeeper([FromBody] CreateDoorkeeperDTO createDoorkeeperDTO)
    {
        var doorkeeper = await _usersService.CreateDoorkeeper(createDoorkeeperDTO);
        return CreatedAtAction(nameof(GetDoorkeeper), new { id = doorkeeper.Id }, doorkeeper);
    }

    [HttpPost("student")]
    [Authorize(Policy = AppConstants.AppPolicies.StudentPolicy)]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO createStudentDTO)
    {
        var student = await _usersService.CreateStudent(createStudentDTO);
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    private readonly IUsersService _usersService;
}

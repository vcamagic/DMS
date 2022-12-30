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

    [HttpGet("students")]
    public async Task<ActionResult<Page<StudentDTO>>> GetStudents([FromQuery] PaginationDTO paginationDTO)
    {
        var students = await _usersService.GetStudents(paginationDTO);
        return Ok(students);
    }

    [HttpGet("wardens")]
    public async Task<ActionResult<IReadOnlyList<WardenDTO>>> GetWardens()
    {
        var wardens = await _usersService.GetWardens();
        return Ok(wardens);
    }

    [HttpGet("janitors")]
    public async Task<ActionResult<IReadOnlyList<EmployeeDTO>>> GetJanitors()
    {
        var janitors = await _usersService.GetJanitors();
        return Ok(janitors);
    }

    [HttpGet("maids")]
    public async Task<ActionResult<IReadOnlyList<EmployeeDTO>>> GetMaids()
    {
        var maids = await _usersService.GetMaids();
        return Ok(maids);
    }

    [HttpGet("doorkeepers")]
    public async Task<ActionResult<IReadOnlyList<EmployeeDTO>>> GetDoorkeepers()
    {
        var doorkeepers = await _usersService.GetDoorkeepers();
        return Ok(doorkeepers);
    }

    [HttpGet("students/{id}")]
    public async Task<ActionResult<StudentDTO>> GetStudent([FromRoute] Guid id)
    {
        var student = await _usersService.GetStudent(id);
        return Ok(student);
    }

    [HttpGet("wardens/{id}")]
    public async Task<ActionResult<StudentDTO>> GetWarden([FromRoute] Guid id)
    {
        var warden = await _usersService.GetWarden(id);
        return Ok(warden);
    }

    [HttpGet("janitors/{id}")]
    public async Task<ActionResult<StudentDTO>> GetJanitor([FromRoute] Guid id)
    {
        var janitor = await _usersService.GetJanitor(id);
        return Ok(janitor);
    }

    [HttpGet("maids/{id}")]
    public async Task<ActionResult<StudentDTO>> GetMaid([FromRoute] Guid id)
    {
        var maid = await _usersService.GetMaid(id);
        return Ok(maid);
    }

    [HttpGet("doorkeepers/{id}")]
    public async Task<ActionResult<StudentDTO>> GetDoorkeeper([FromRoute] Guid id)
    {
        var doorkeeper = await _usersService.GetDoorkeeper(id);
        return Ok(doorkeeper);
    }

    [HttpPost("{accountId}/wardens")]
    [Authorize(Policy = AppConstants.AppPolicies.WardenPolicy)]
    public async Task<IActionResult> CreateWarden(
        [FromRoute] Guid accountId, 
        [FromBody] CreateWardenDTO createWardenDTO)
    {
        var warden = await _usersService.CreateWarden(accountId, createWardenDTO);
        return CreatedAtAction(nameof(GetWarden), new { id = warden.Id }, warden);
    }

    [HttpPost("{accountId}/janitors")]
    [Authorize(Policy = AppConstants.AppPolicies.OwnsAccountPolicy)]
    public async Task<IActionResult> CreateJanitor(
        [FromRoute] Guid accountId, 
        [FromBody] CreateJanitorDTO createJanitorDTO)
    {
        var janitor = await _usersService.CreateJanitor(accountId, createJanitorDTO);
        return CreatedAtAction(nameof(GetJanitor), new { id = janitor.Id }, janitor);
    }

    [HttpPost("{accountId}/maids")]
    [Authorize(Policy = AppConstants.AppPolicies.MaidPolicy)]
    public async Task<IActionResult> CreateMaid(
        [FromRoute] Guid accountId,
        [FromBody] CreateMaidDTO createMaidDTO)
    {
        var maid = await _usersService.CreateMaid(accountId, createMaidDTO);
        return CreatedAtAction(nameof(GetMaid), new { id = maid.Id }, maid);
    }

    [HttpPost("{accountId}/doorkeepers")]
    [Authorize(Policy = AppConstants.AppPolicies.DoorkeeperPolicy)]
    public async Task<IActionResult> CreateDoorkeeper(
        [FromRoute] Guid accountId,
        [FromBody] CreateDoorkeeperDTO createDoorkeeperDTO)
    {
        var doorkeeper = await _usersService.CreateDoorkeeper(accountId, createDoorkeeperDTO);
        return CreatedAtAction(nameof(GetDoorkeeper), new { id = doorkeeper.Id }, doorkeeper);
    }

    [HttpPost("{accountId}/students")]
    [Authorize(Policy = AppConstants.AppPolicies.StudentPolicy)]
    public async Task<IActionResult> CreateStudent(
        [FromRoute] Guid accountId,
        [FromBody] CreateStudentDTO createStudentDTO)
    {
        var student = await _usersService.CreateStudent(accountId, createStudentDTO);
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    [HttpPut("{accountId}/students/{id}")]
    [Authorize(Policy = AppConstants.AppPolicies.OwnsAccountPolicy)]
    public async Task<ActionResult<StudentDTO>> UpdateStudent(
        [FromRoute] Guid accountId,
        [FromRoute] Guid id,
        [FromBody] UpdateStudentDTO updateStudentDTO)
    {
        var student = await _usersService.UpdateStudent(accountId, id, updateStudentDTO);
        return Ok(student);
    }

    [HttpPut("{accountId}/wardens/{id}")]
    [Authorize(Policy = AppConstants.AppPolicies.OwnsAccountPolicy)]
    public async Task<ActionResult<WardenDTO>> UpdateWarden(
        [FromRoute] Guid accountId,
        [FromRoute] Guid id,
        [FromBody] UpdateWardenDTO updateWardenDTO)
    {
        var warden = await _usersService.UpdateWarden(accountId, id, updateWardenDTO);
        return Ok(warden);
    }

    [HttpPut("{accountId}/janitors/{id}")]
    [Authorize(Policy = AppConstants.AppPolicies.OwnsAccountPolicy)]
    public async Task<ActionResult<EmployeeDTO>> UpdateJanitor(
        [FromRoute] Guid accountId,
        [FromRoute] Guid id,
        [FromBody] UpdateJanitorDTO updateJanitorDTO)
    {
        var janitor = await _usersService.UpdateJanitor(accountId, id, updateJanitorDTO);
        return Ok(janitor);
    }

    [HttpPut("{accountId}/maids/{id}")]
    [Authorize(Policy = AppConstants.AppPolicies.OwnsAccountPolicy)]
    public async Task<ActionResult<EmployeeDTO>> UpdateMaid(
        [FromRoute] Guid accountId,
        [FromRoute] Guid id,
        [FromBody] UpdateMaidDTO updateMaidDTO)
    {
        var maid = await _usersService.UpdateMaid(accountId, id, updateMaidDTO);
        return Ok(maid);
    }

    [HttpPut("{accountId}/doorkeepers/{id}")]
    [Authorize(Policy = AppConstants.AppPolicies.OwnsAccountPolicy)]
    public async Task<ActionResult<EmployeeDTO>> UpdateDoorkeeper(
        [FromRoute] Guid accountId,
        [FromRoute] Guid id,
        [FromBody] UpdateDoorkeeperDTO updateDoorkeeperDTO)
    {
        var doorkeeper = await _usersService.UpdateDoorkeeper(accountId, id, updateDoorkeeperDTO);
        return Ok(doorkeeper);
    }

    private readonly IUsersService _usersService;
}

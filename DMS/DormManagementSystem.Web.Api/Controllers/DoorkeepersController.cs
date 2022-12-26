using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormManagementSystem.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DoorkeepersController : ControllerBase
{
    public DoorkeepersController(IDoorkeepersService doorkeepersService)
    {
        _doorkeepersService = doorkeepersService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoorkeeperDTO>> GetDoorkeeper([FromRoute] Guid doorkeeperId)
    {
        var doorkeeper = await _doorkeepersService.GetDoorkeeper(doorkeeperId);
        return Ok(doorkeeper);
    }

    [HttpGet]
    public async Task<ActionResult<DoorkeeperDTO>> GetDoorkeepers([FromQuery] PaginationDTO paginationDTO)
    {
        var doorkeeper = await _doorkeepersService.GetDoorkeepers(paginationDTO);
        return Ok(doorkeeper);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoorkeeper([FromBody] CreateDoorkeeperDTO createDoorkeeperDTO)
    {
        var doorkeeper = await _doorkeepersService.CreateDoorkeeper(createDoorkeeperDTO);
        return NoContent();
    }

    private readonly IDoorkeepersService _doorkeepersService;
}

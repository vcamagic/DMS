using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DormManagementSystem.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoorkeepersController : ControllerBase
{
    public DoorkeepersController(IDoorkeepersService doorkeepersService)
    {
        _doorkeepersService = doorkeepersService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoorkeeper([FromBody] CreateDoorkeeperDTO createDoorkeeperDTO)
    {
        var doorkeeper = await _doorkeepersService.CreateDoorkeeper(createDoorkeeperDTO);
        return NoContent();
    }

    private readonly IDoorkeepersService _doorkeepersService;
}

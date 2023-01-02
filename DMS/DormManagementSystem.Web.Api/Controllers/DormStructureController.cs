
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormManagementSystem.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = AppConstants.AppPolicies.WardenPolicy)]
public class DormStructureController : ControllerBase
{
    public DormStructureController(IDormStructureService dormStructureService)
    {
        _dormStructureService = dormStructureService;
    }

    [HttpPost("multiple-floors")]
    public async Task<IActionResult> CreateFloors([FromBody] CreateFloorsDTO createFloorsDTO)
    {
        await _dormStructureService.CreateFloors(createFloorsDTO.FloorDTOs);
        return Ok();
    }

    [HttpPost("floors")]
    public async Task<IActionResult> CreateFloor([FromBody] CreateFloorDTO createFloorDTO)
    {
        await _dormStructureService.CreateFloor(createFloorDTO);
        return Ok();
    }

    [HttpPost("{floorId}/rooms")]
    public async Task<IActionResult> CreateRoomsOnFloor([FromRoute] Guid floorId, [FromBody] IEnumerable<RoomDTO> rooms)
    {
        await _dormStructureService.CreateRoomsOnFloor(floorId, rooms);
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateDormStructure([FromBody] DormStructureBatch batch)
    {

        return Ok();
    }

    private readonly IDormStructureService _dormStructureService;
}
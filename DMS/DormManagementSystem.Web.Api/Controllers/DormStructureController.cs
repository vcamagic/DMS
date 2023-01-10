
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

    [HttpGet]
    public async Task<IActionResult> GetDormStructure()
    {
        var dorm = await _dormStructureService.GetDormStructure();
        return Ok(dorm);
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

    [HttpPost("{floorId}/residencies")]
    public async Task<ActionResult<Page<RoomDTO>>> AddResidenciesToFloor(
        [FromRoute] Guid floorId,
        [FromBody] CreateResidenciesDTO residenciesDTO,
        [FromQuery] int pageNumber = 1)
    {
        await _dormStructureService.AddResidenciesToFloor(floorId, residenciesDTO);
        return Ok(new { message = $"Rooms added successfully, page {pageNumber}", residenciesDTO.Residencies });
    }

    [HttpPost("{floorId}/laundries")]
    public async Task<IActionResult> AddLaundryToFloor([FromRoute] Guid floorId, [FromBody] CreateLaundryDTO createLaundryDTO)
    {
        await _dormStructureService.AddLaundryToFloor(floorId, createLaundryDTO);
        return NoContent();
    }

    [HttpPost("{floorId}/entertainments")]
    public async Task<IActionResult> AddEntertainmentToFloor([FromRoute] Guid floorId, [FromBody] CreateEntertainmentDTO createEntertainmentDTO)
    {
        await _dormStructureService.AddEntertainmentToFloor(floorId, createEntertainmentDTO);
        return NoContent();
    }

    [HttpDelete("rooms/{roomId}")]
    public async Task<IActionResult> DeleteRoom([FromRoute] Guid roomId)
    {
        await _dormStructureService.DeleteRoom(roomId);
        return NoContent();
    }

    private readonly IDormStructureService _dormStructureService;
}
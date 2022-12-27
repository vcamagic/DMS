using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DormManagementSystem.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MalfunctionsController : ControllerBase
{
    public MalfunctionsController(IMalfunctionsService malfunctionsService)
    {
        _malfunctionsService = malfunctionsService;
    }

    [HttpGet]
    public async Task<ActionResult<Page<MalfunctionDTO>>> GetMalfunctions(
        [FromQuery] PaginationDTO paginationDTO,
        [FromQuery] SortDTO sortDTO,
        [FromQuery] bool? resolved = null)
    {
        var malfunctions = await _malfunctionsService.GetMalfunctions(paginationDTO, sortDTO, resolved);
        return Ok(malfunctions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MalfunctionDTO>> GetMalfunction([FromRoute] Guid id)
    {
        var malfunction = await _malfunctionsService.GetMalfunction(id);
        return Ok(malfunction);
    }

    [HttpPost]
    [Authorize(Policy = AppConstants.AppPolicies.StudentPolicy)]
    public async Task<IActionResult> CreateMalfunction([FromBody] CreateMalfunctionDTO createMalfunctionDTO)
    {
        var malfunction = await _malfunctionsService.CreateMalfunction(createMalfunctionDTO);
        return CreatedAtAction(nameof(GetMalfunction), new { id = malfunction.Id }, malfunction);
    }

    [HttpPatch("{id}")]
    [Authorize(Policy = AppConstants.AppPolicies.JanitorPolicy)]
    public async Task<IActionResult> PatchMalfunction([FromRoute] Guid id, [FromBody] JsonPatchDocument<UpdateMalfunctionDTO> patchDocument)
    {
        await _malfunctionsService.UpdateMalfunction(id, patchDocument);
        return NoContent();
    }

    private readonly IMalfunctionsService _malfunctionsService;
}

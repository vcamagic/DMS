using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormManagementSystem.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = AppConstants.AppPolicies.WardenMaidPolicy)]
public class WashingMachinesController : ControllerBase
{
    public WashingMachinesController(IWashingMachinesService washingMachinesService)
    {
        _washingMachinesService = washingMachinesService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ResponseWashingMachineDTO>>> GetWashingMachines()
    {
        var washingMachines = await _washingMachinesService.GetWashingMachines();
        return Ok(washingMachines);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseWashingMachineDTO>> GetWashingMachine([FromRoute] Guid id)
    {
        var washingMachine = await _washingMachinesService.GetWashingMachine(id);
        return Ok(washingMachine);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWashingMachine([FromBody] RequestWashingMachineDTO requestWashingMachineDTO)
    {
        var washingMachine = await _washingMachinesService.CreateWashingMachine(requestWashingMachineDTO);
        return CreatedAtAction(nameof(GetWashingMachine), new { id = washingMachine.Id }, washingMachine);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWashingMachine([FromRoute] Guid id, [FromBody] RequestWashingMachineDTO requestWashingMachineDTO)
    {
        var washingMachine = await _washingMachinesService.UpdateWashingMachine(id, requestWashingMachineDTO);
        return CreatedAtAction(nameof(GetWashingMachine), new { id = washingMachine.Id }, washingMachine);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWashingMachine([FromRoute] Guid id)
    {
        await _washingMachinesService.DeleteWashingMachine(id);
        return NoContent();
    }

    private readonly IWashingMachinesService _washingMachinesService;
}
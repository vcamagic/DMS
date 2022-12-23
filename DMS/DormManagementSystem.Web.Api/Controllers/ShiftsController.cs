using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DormManagementSystem.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftsController : ControllerBase
{
    public ShiftsController(IShiftsService shiftsService)
    {
        _shiftsService = shiftsService;
    }

    [HttpGet]
    public async Task<ActionResult<Page<ShiftDTO>>> GetShifts([FromRoute] PaginationDTO paginationDTO)
    {
        var shifts = await _shiftsService.GetShifts(paginationDTO);
        return Ok(shifts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShiftDTO>> GetShift([FromRoute] Guid id)
    {
        var shift = await _shiftsService.GetShift(id);
        return Ok(shift);
    }

    [HttpPost]
    public async Task<IActionResult> CreateShift([FromBody] CreateShiftDTO createShiftDTO)
    {
        var shift = await _shiftsService.CreateShift(createShiftDTO);

        return CreatedAtAction(nameof(GetShift), new { id = shift.Id }, shift);
    }

    private readonly IShiftsService _shiftsService;
}

using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DormManagementSystem.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JanitorsController : ControllerBase
{
    public JanitorsController(IJanitorsService janitorsService)
    {
        _janitorsService = janitorsService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateJanitor([FromBody] CreateJanitorDTO createJanitorDTO)
    {
        var janitor = await _janitorsService.CreateJanitor(createJanitorDTO);
        
        return NoContent();
    }

    private readonly IJanitorsService _janitorsService;
}

using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
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

    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] PaginationDTO paginationDTO)
    {
        var users = await _usersService.GetUsers(paginationDTO);
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        var user = await _usersService.GetUser(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDTO createUserDTO)
    {
        var user = await _usersService.Create(createUserDTO);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserDTO updateUserDTO)
    {
        await _usersService.Update(id, updateUserDTO);
        return NoContent();
    }

    private readonly IUsersService _usersService;
}

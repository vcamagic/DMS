using DormManagementSystem.BLL.Services.DTOs;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IUsersService
{
    Task<Page<UserDTO>> GetUsers(PaginationDTO paginationDTO);
    Task<UserDTO> GetUser(Guid id);
    Task<UserDTO> Create(CreateUserDTO createUserDTO);
    Task Update(Guid id, UpdateUserDTO createUserDTO);
}

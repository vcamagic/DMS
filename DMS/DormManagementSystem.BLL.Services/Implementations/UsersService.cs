using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;

namespace DormManagementSystem.BLL.Services.Implementations;

public class UsersService : ServiceBase<User>, IUsersService
{
    public UsersService(
        IRepositoryBase<User> repository,
        IMapper mapper,
        IAccountsService accountsService) : base(repository, mapper)
    {
        _accountsService = accountsService;
    }

    public async Task<UserDTO> GetUser(Guid id)
    {
        var user = await GetEntity(x => x.Id == id, false, x => x.Account) ??
            throw new BadRequestException($"User with id {id} does not exist.");

        return Mapper.Map<UserDTO>(user);
    }

    public async Task<IReadOnlyList<UserDTO>> GetUsers(PaginationDTO paginationDTO)
    {
        var users = await GetEntityPage(paginationDTO, false, x => x.Account);

        return Mapper.Map<IReadOnlyList<UserDTO>>(users);
    }

    public async Task<UserDTO> Create(CreateUserDTO createUserDTO)
    {
        var account = await _accountsService.GetAccount(createUserDTO.AccountId)
            ?? throw new BadRequestException($"Account with id {createUserDTO.AccountId} does not exist.");

        var existingUser = await GetEntity(x => x.AccountId == account.Id, false);

        if (existingUser != null)
        {
            throw new BadRequestException($"There is already a user associated with account with id {createUserDTO.AccountId}.");
        }
        
        var user = Mapper.Map<User>(createUserDTO);
        await Create(user);

        return Mapper.Map<UserDTO>(user);
    }

    public async Task Update(Guid id, UpdateUserDTO updateUserDTO)
    {
        var user = await GetEntity(x => x.Id == id, true)
            ?? throw new BadRequestException($"User with id {id} was not found");
        
        Mapper.Map(updateUserDTO, user);
        await Update(user);
    }

    private readonly IAccountsService _accountsService;
}

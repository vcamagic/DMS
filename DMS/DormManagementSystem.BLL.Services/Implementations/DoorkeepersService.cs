using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.BLL.Services.Implementations;

public class DoorkeepersService : ServiceBase<Doorkeeper>, IDoorkeepersService
{
    public DoorkeepersService(
        IRepositoryBase<Doorkeeper> repository,
        IAccountsService accountsService,
        IMapper mapper) : base(repository, mapper)
    {
        _accountsService = accountsService;
    }


    public async Task<DoorkeeperDTO> GetDoorkeeper(Guid id)
    {
        var doorkeeper = await GetEntity(x => x.Id == id, false) ??
            throw new BadRequestException($"User with id {id} does not exist.");

        return Mapper.Map<DoorkeeperDTO>(doorkeeper);
    }

    public async Task<DoorkeeperDTO> CreateDoorkeeper(CreateDoorkeeperDTO createDoorkeeperDTO)
    {
        var user = await GetEntity(x => x.AccountId == createDoorkeeperDTO.AccountId, false);

        if (user != null)
        {
            throw new BadRequestException($"User already exists for Account with id {createDoorkeeperDTO.AccountId}.");
        }

        var hasClaim = await _accountsService.AccountHasClaim(createDoorkeeperDTO.AccountId, new("Role", "Doorkeeper"));

        if (!hasClaim)
        {
            throw new BadRequestException("User is not a doorkeeper.");
        }

        var doorkeeper = Mapper.Map<Doorkeeper>(createDoorkeeperDTO);

        await Create(doorkeeper);

        return Mapper.Map<DoorkeeperDTO>(doorkeeper);
    }

    public async Task<Page<DoorkeeperDTO>> GetDoorkeepers(PaginationDTO paginationDTO)
    {
        var doorkeepers = await GetEntityPage(paginationDTO, false);
        return Mapper.Map<Page<DoorkeeperDTO>>(doorkeepers);
    }

    private readonly IAccountsService _accountsService;
}

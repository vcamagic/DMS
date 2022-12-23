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
    public DoorkeepersService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
    {
    }

    public async Task<DoorkeeperDTO> CreateDoorkeeper(CreateDoorkeeperDTO createDoorkeeperDTO)
    {
        var user = await GetEntity(x => x.AccountId == createDoorkeeperDTO.AccountId, false);

        if (user != null)
        {
            throw new BadRequestException($"User already exists for Account with id {createDoorkeeperDTO.AccountId}.");
        }

        var account = await RepositoryManager
            .AccountRepository.FindByCondition(x => x.Id == createDoorkeeperDTO.AccountId, false).FirstOrDefaultAsync() ??
            throw new BadRequestException($"Account with id {createDoorkeeperDTO.AccountId} does not exist.");

        _ = account.Claims.FirstOrDefault(x => x.Name == "Role" && x.Value == "Janitor") ??
            throw new BadRequestException($"Account with id {createDoorkeeperDTO.AccountId} is not a janitor.");

        var doorkeeper = Mapper.Map<Doorkeeper>(createDoorkeeperDTO);

        await Create(doorkeeper);

        return Mapper.Map<DoorkeeperDTO>(doorkeeper);
    }
}

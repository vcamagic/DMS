using System.Linq.Expressions;
using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.BLL.Services.Implementations;

public class JanitorsService : ServiceBase<Janitor>, IJanitorsService
{
    public JanitorsService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<JanitorDTO> CreateJanitor(CreateJanitorDTO createJanitorDTO)
    {
        var user = await GetEntity(x => x.AccountId == createJanitorDTO.AccountId, false);

        if (user != null)
        {
            throw new BadRequestException($"User already exists for Account with id {createJanitorDTO.AccountId}.");
        }

        var account = await _repositoryManager
            .AccountRepository.FindByCondition(x => x.Id == createJanitorDTO.AccountId, false).FirstOrDefaultAsync() ??
            throw new BadRequestException($"Account with id {createJanitorDTO.AccountId} does not exist.");

        _ = account.Claims.FirstOrDefault(x => x.Name == "Role" && x.Value == "Janitor") ??
            throw new BadRequestException($"Account with id {createJanitorDTO.AccountId} is not a janitor.");

        var janitor = Mapper.Map<Janitor>(createJanitorDTO);

        await Create(janitor);

        return Mapper.Map<JanitorDTO>(janitor);
    }

    private readonly IRepositoryManager _repositoryManager;
}

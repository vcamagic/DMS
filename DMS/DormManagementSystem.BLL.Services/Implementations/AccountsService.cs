using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.BLL.Services.Implementations;

public class AccountsService : ServiceBase<Account>, IAccountsService
{
    public AccountsService(
        IRepositoryManager repositoryManager,
        IMapper mapper,
        IRepositoryBase<Account> repositoryBase) : base(repositoryBase)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    public async Task ActivateAccount(Guid accountId)
    {
        var account = await GetEntity(x => x.Id == accountId, true) ?? 
            throw new BadRequestException($"Account with Id {accountId} does not exist.");

        account.IsActive = true;

        await _repositoryManager.SaveAsync();
    }

    public async Task<IReadOnlyList<AccountDTO>> GetAccounts(PaginationDTO paginationDTO)
    {
        var accounts = await GetEntityPage(paginationDTO, false, x => x.Claims); 
        return _mapper.Map<IReadOnlyList<AccountDTO>>(accounts);
    }

    public async Task<AccountDTO> GetAccount(Guid id)
    {
        var account = await GetEntity(x => x.Id == id, false, x => x.Claims) ?? 
            throw new BadRequestException($"Account with id {id} does not exist.");

        return _mapper.Map<AccountDTO>(account);
    }

    public async Task<AccountDTO> GetAccount(string email)
    {
        var account = await GetEntity(x => x.Email == email, false, x => x.Claims) ??
            throw new BadRequestException($"Account with email {email} does not exist.");

        return _mapper.Map<AccountDTO>(account);
    }

    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
}

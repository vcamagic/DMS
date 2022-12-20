using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.BLL.Services.Implementations;

public class AccountsService : IAccountsService
{
    public AccountsService(
        IRepositoryManager repositoryManager,
        IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    public async Task ActivateAccount(Guid accountId)
    {
        var account = await _repositoryManager
            .AccountRepository
            .FindByCondition(x => x.Id == accountId, true)
            .FirstOrDefaultAsync() ?? throw new BadRequestException($"Account with Id {accountId} does not exist.");

        account.IsActive = true;

        await _repositoryManager.SaveAsync();
    }

    public async Task<IReadOnlyList<AccountDTO>> GetAccounts(PaginationDTO paginationDTO)
    {
        var accounts = await _repositoryManager
            .AccountRepository
            .FindAll(false)
            .Include(x => x.Claims)
            .Skip(paginationDTO.Page * paginationDTO.PageSize)
            .Take(paginationDTO.PageSize)
            .ToListAsync();

        return _mapper.Map<IReadOnlyList<AccountDTO>>(accounts);
    }

    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
}

using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;

namespace DormManagementSystem.BLL.Services.Implementations;

public class AccountsService : ServiceBase<Account>, IAccountsService
{
    public AccountsService(
        IRepositoryManager repositoryManager,
        IMapper mapper) : base(repositoryManager.AccountRepository, mapper)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task ActivateAccount(Guid accountId)
    {
        var account = await GetEntity(x => x.Id == accountId, true) ??
            throw new BadRequestException($"Account with Id {accountId} does not exist.");

        account.IsActive = true;

        await _repositoryManager.SaveAsync();
    }

    public async Task<Page<AccountDTO>> GetAccounts(
        PaginationDTO paginationDTO,
        SortDTO sortDTO = null,
        bool? active = null)
    {
        var includeClaims = new string[] { nameof(Account) };

        var accountsPage = sortDTO switch
        {
            null => await GetEntityPage(paginationDTO, x => active == null || x.IsActive == active, false),
            { SortBy: "email" } => 
                await GetEntityPage(
                    paginationDTO, 
                    x => active == null || x.IsActive == active, 
                    false, 
                    orderSelector: x => x.Email, 
                    orderAscending: sortDTO.Order != "desc" , 
                    includes: includeClaims
                ),
            { SortBy: "isActive" } => 
                await GetEntityPage(
                    paginationDTO, 
                    x => active == null || x.IsActive == active, 
                    false, 
                    orderSelector: x => x.IsActive, 
                    orderAscending: sortDTO.Order != "desc" , 
                    includes: includeClaims
                ),
            _ => await GetEntityPage(
                    paginationDTO, 
                    x => active == null || x.IsActive == active, 
                    false, 
                    includes: includeClaims
                )
        };

        return Mapper.Map<Page<AccountDTO>>(accountsPage);
    }

    public async Task<AccountDTO> GetAccount(Guid id)
    {
        var account = await GetEntity(x => x.Id == id, false, new string[] { nameof(Account) }) ??
            throw new BadRequestException($"Account with id {id} does not exist.");

        return Mapper.Map<AccountDTO>(account);
    }

    public async Task<AccountDTO> GetAccount(string email)
    {
        var account = await GetEntity(x => x.Email == email, false, new string[] { nameof(Account) }) ??
            throw new BadRequestException($"Account with email address {email} does not exist."); ;

        return Mapper.Map<AccountDTO>(account);
    }

    public async Task<AccountDTO> CreateAccount(CreateAccountDTO createAccountDTO)
    {
        var account = Mapper.Map<Account>(createAccountDTO);

        await Create(account);

        return Mapper.Map<AccountDTO>(account);
    }

    public async Task<bool> AccountHasRole(Guid id, string role)
    {
        var account = await GetAccount(id);

        return true;
    }

    private readonly IRepositoryManager _repositoryManager;
}

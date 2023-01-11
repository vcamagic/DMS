using System.Linq.Expressions;
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

        var accountsPage = await GetEntityPage(
            paginationDTO: paginationDTO,
            expression: x => active == null || x.IsActive == active,
            trackChanges: false,
            orderSelector: CreateOrderSelector(sortDTO.SortBy),
            orderAscending: sortDTO.Order != "desc"
        );

        return Mapper.Map<Page<AccountDTO>>(accountsPage);
    }

    public async Task<AccountDTO> GetAccount(Guid id)
    {
        var account = await GetEntity(x => x.Id == id, false) ??
            throw new NotFoundException($"Account with id {id} does not exist.");

        return Mapper.Map<AccountDTO>(account);
    }

    public async Task<AccountDTO> GetAccount(string email)
    {
        var account = await GetEntity(x => x.Email == email, false) ??
            throw new NotFoundException($"Account with email address {email} does not exist."); ;

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

    private Expression<Func<Account, object>> CreateOrderSelector(string orderBy = null) =>
        orderBy switch
        {
            "email" => x => x.Email,
            "isActive" => x => x.IsActive,
            _ => null
        };

    private readonly IRepositoryManager _repositoryManager;
}

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
        var includeClaims = new string[] { nameof(Account.Claims) };

        var accountsPage = sortDTO switch
        {
            null => await GetEntityPage(paginationDTO, false),
            { SortBy: "email" } => sortDTO.Order == "desc" ?
                await GetEntityPage(paginationDTO, false, orderSelector: x => x.Email, orderAscending: false, includes: includeClaims) :
                await GetEntityPage(paginationDTO, false, orderSelector: x => x.Email, includes: includeClaims),
            { SortBy: "isActive" } => sortDTO.Order == "desc" ?
                await GetEntityPage(paginationDTO, false, orderSelector: x => x.IsActive, orderAscending: false, includes: includeClaims) :
                await GetEntityPage(paginationDTO, false, orderSelector: x => x.IsActive, includes: includeClaims),
            _ => await GetEntityPage(paginationDTO, false, includes: includeClaims)
        };

        return Mapper.Map<Page<AccountDTO>>(accountsPage);
    }

    public async Task<AccountDTO> GetAccount(Guid id)
    {
        var account = await GetEntity(x => x.Id == id, false, new string[] { nameof(Account.Claims) }) ??
            throw new BadRequestException($"Account with id {id} does not exist.");

        return Mapper.Map<AccountDTO>(account);
    }

    public async Task<AccountDTO> GetAccount(string email)
    {
        var account = await GetEntity(x => x.Email == email, false, new string[] { nameof(Account.Claims) }) ??
            throw new BadRequestException($"Account with email address {email} does not exist."); ;

        return Mapper.Map<AccountDTO>(account);
    }

    public async Task<AccountDTO> CreateAccount(CreateAccountDTO createAccountDTO)
    {
        var account = Mapper.Map<Account>(createAccountDTO);

        await Create(account);

        return Mapper.Map<AccountDTO>(account);
    }

    public async Task<bool> AccountHasClaim(Guid id, (string name, string value) claim)
    {
        var account = await GetAccount(id);

        return account.Claims.Any(x => x.Name == claim.name && x.Value == claim.value);
    }

    private static ICollection<Claim> ConvertRolesToClaims(IEnumerable<Role> roles) =>
    roles.Select(x =>
    {
        return x switch
        {
            Role.Administrator => new Claim("Role", "Administrator"),
            Role.Warden => new Claim("Role", "Warden"),
            Role.Maid => new Claim("Role", "Maid"),
            Role.Doorkeeper => new Claim("Role", "Doorkeeper"),
            Role.Janitor => new Claim("Role", "Janitor"),
            Role.Student => new Claim("Role", "Student"),
            _ => new Claim()
        };
    }).ToList();


    private readonly IRepositoryManager _repositoryManager;
}

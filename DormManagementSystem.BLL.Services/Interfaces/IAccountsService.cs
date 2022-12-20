using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IAccountsService
{
    public Task<IReadOnlyList<AccountDTO>> GetAccounts(PaginationDTO paginationDTO);
    public Task ActivateAccount(Guid accountId);
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IAccountsService : IServiceBase<Account>
{
    public Task<Page<AccountDTO>> GetAccounts(PaginationDTO paginationDTO, bool? active = null);
    public Task<AccountDTO> GetAccount(Guid id);
    public Task<AccountDTO> GetAccount(string email);
    public Task ActivateAccount(Guid accountId);
}

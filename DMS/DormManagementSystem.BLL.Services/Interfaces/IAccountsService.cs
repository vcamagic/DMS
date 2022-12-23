using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IAccountsService : IServiceBase<Account>
{
    Task<Page<AccountDTO>> GetAccounts(PaginationDTO paginationDTO, bool? active = null);
    Task<AccountDTO> GetAccount(Guid id);
    Task<AccountDTO> GetAccount(string email);
    Task<AccountDTO> CreateAccount(CreateAccountDTO createAccountDTO);
    Task ActivateAccount(Guid accountId);
}

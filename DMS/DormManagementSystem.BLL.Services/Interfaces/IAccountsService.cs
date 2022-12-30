using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IAccountsService
{
    Task<Page<AccountDTO>> GetAccounts(PaginationDTO paginationDTO, SortDTO sortDTO = null, bool? active = null);
    Task<AccountDTO> GetAccount(Guid id);
    Task<AccountDTO> GetAccount(string email);
    Task<AccountDTO> CreateAccount(CreateAccountDTO createAccountDTO);
    Task ActivateAccount(Guid accountId);

    ///<summary>
    /// Determines weather account with <paramref name="id"></paramref> has a <paramref name="claim"></paramref> with given <paramref name="name"></paramref> and <paramref name="value"></paramref>.
    ///</summary>
    ///<returns>Flag indicating weather account has specified claim.</returns>
    ///<exception cref="BadRequestException">Thrown when account with <c>id</c> doesn't exist.</exception>
    Task<bool> AccountHasRole(Guid id, string role);
}

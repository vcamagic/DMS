using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;

namespace DormManagementSystem.DAL.Repositories.Implementations;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(ApplicationContext context) : base(context)
    {
    }
}

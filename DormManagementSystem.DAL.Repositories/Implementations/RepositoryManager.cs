using DormManagementSystem.DAL.Repositories.Interfaces;

namespace DormManagementSystem.DAL.Repositories.Implementations;

public class RepositoryManager : IRepositoryManager
{
    public RepositoryManager(Parameters)
    {
        
    }
    public IAccountRepository _accountRepository { get; }

    public IAccountRepository AccountRepository 
    {
        get {
            if(_accountRepository == null){
                _accountRepository = new AccountRepository()
            }
        }
    }

}

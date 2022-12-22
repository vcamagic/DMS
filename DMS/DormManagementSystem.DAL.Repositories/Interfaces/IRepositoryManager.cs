using DormManagementSystem.DAL.Models;

namespace DormManagementSystem.DAL.Repositories.Interfaces;

public interface IRepositoryManager
{
    public ApplicationContext Context {get;}    
    public IAccountRepository AccountRepository { get;}
    public IUserRepository UserRepository { get;}
    public Task SaveAsync();
}

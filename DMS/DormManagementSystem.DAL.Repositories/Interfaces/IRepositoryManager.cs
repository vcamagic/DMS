using DormManagementSystem.DAL.Models;

namespace DormManagementSystem.DAL.Repositories.Interfaces;

public interface IRepositoryManager
{
    public ApplicationContext Context {get;}    
    public IAccountRepository AccountRepository { get;}
    public Task SaveAsync();
}

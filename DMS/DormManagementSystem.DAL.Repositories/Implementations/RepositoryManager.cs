using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;

namespace DormManagementSystem.DAL.Repositories.Implementations;

public class RepositoryManager : IRepositoryManager
{
    public RepositoryManager(ApplicationContext context)
    {
        _context = context;
    }

    public ApplicationContext Context => _context;    

    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(_context);
            }

            return _userRepository;
        }
    }

    public IAccountRepository AccountRepository
    {
        get
        {
            if (_accountRepository == null)
            {
                _accountRepository = new AccountRepository(_context);
            }

            return _accountRepository;
        }
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    private readonly ApplicationContext _context;
    private IAccountRepository _accountRepository;    
    private IUserRepository _userRepository;    
}

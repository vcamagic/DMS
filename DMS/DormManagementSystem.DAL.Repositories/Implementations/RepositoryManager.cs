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

    public IDoorkeeperRepository DoorkeeperRepository
    {
        get
        {
            if (_doorkeeperRepository == null)
            {
                _doorkeeperRepository = new DoorkeeperRepository(_context);
            }

            return _doorkeeperRepository;
        }
    }

    public IEmployeeRepository EmployeeRepository
    {
        get
        {
            if (_employeeRepository == null)
            {
                _employeeRepository = new EmployeeRepository(_context);
            }

            return _employeeRepository;
        }
    }

    public IShiftRepository ShiftRepository
    {
        get
        {
            if (_shiftRepository == null)
            {
                _shiftRepository = new ShiftRepository(_context);
            }

            return _shiftRepository;
        }
    }

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

    public IStudentRepository StudentRepository
    {
        get
        {
            if (_studentRepository == null)
            {
                _studentRepository = new StudentRepository(_context);
            }

            return _studentRepository;
        }
    }

    public IJanitorRepository JanitorRepository
    {
        get
        {
            if (_janitorRepository == null)
            {
                _janitorRepository = new JanitorRepository(_context);
            }

            return _janitorRepository;
        }
    }

    public IMaidRepository MaidRepository
    {
        get
        {
            if (_maidRepository == null)
            {
                _maidRepository = new MaidRepository(_context);
            }

            return _maidRepository;
        }
    }

    public IWardenRepository WardenRepository
    {
        get
        {
            if (_wardenRepository == null)
            {
                _wardenRepository = new WardenRepository(_context);
            }

            return _wardenRepository;
        }
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    private readonly ApplicationContext _context;
    private IAccountRepository _accountRepository;
    private IUserRepository _userRepository;
    private IShiftRepository _shiftRepository;
    private IEmployeeRepository _employeeRepository;
    private IDoorkeeperRepository _doorkeeperRepository;
    private IJanitorRepository _janitorRepository;
    private IMaidRepository _maidRepository;
    private IWardenRepository _wardenRepository;
    private IStudentRepository _studentRepository;
}

using DormManagementSystem.DAL.Models;

namespace DormManagementSystem.DAL.Repositories.Interfaces;

public interface IRepositoryManager
{
    public ApplicationContext Context { get; }
    public IAccountRepository AccountRepository { get; }
    public IUserRepository UserRepository { get; }
    public IShiftRepository ShiftRepository { get; }
    public IEmployeeRepository EmployeeRepository { get; }
    public IDoorkeeperRepository DoorkeeperRepository { get; }
    public IJanitorRepository JanitorRepository { get; }
    public IMaidRepository MaidRepository { get; }
    public IWardenRepository WardenRepository { get; }
    public IStudentRepository StudentRepository { get; }
    public Task SaveAsync();
}

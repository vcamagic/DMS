using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;

namespace DormManagementSystem.DAL.Repositories.Implementations;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(ApplicationContext context) : base(context)
    {
    }
}

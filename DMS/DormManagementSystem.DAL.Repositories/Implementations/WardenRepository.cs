using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;

namespace DormManagementSystem.DAL.Repositories.Implementations;

public class WardenRepository : RepositoryBase<Warden>, IWardenRepository
{
    public WardenRepository(ApplicationContext context) : base(context)
    {
    }
}

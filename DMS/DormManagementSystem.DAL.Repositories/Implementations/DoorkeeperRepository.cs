
using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Implementations;
using DormManagementSystem.DAL.Repositories.Interfaces;

public class DoorkeeperRepository : RepositoryBase<Doorkeeper>, IDoorkeeperRepository
{
    public DoorkeeperRepository(ApplicationContext context) : base(context)
    {
    }
}
using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;

namespace DormManagementSystem.DAL.Repositories.Implementations;

public class JanitorRepository : RepositoryBase<Janitor>, IJanitorRepository
{
    public JanitorRepository(ApplicationContext context) : base(context)
    {
    }
}

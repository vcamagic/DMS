using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;

namespace DormManagementSystem.DAL.Repositories.Implementations;

public class ShiftRepository : RepositoryBase<Shift>, IShiftRepository
{
    public ShiftRepository(ApplicationContext context) : base(context)
    {
    }
}

using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.DAL.Repositories.Interfaces;

public interface IMalfunctionRepository : IRepositoryBase<Malfunction>
{
    public Task AddJanitorsToMalfunction(Guid malfunctionId, IEnumerable<Guid> janitors);
}
using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;

namespace DormManagementSystem.DAL.Repositories.Implementations;

public class MalfunctionRepository : RepositoryBase<Malfunction>, IMalfunctionRepository
{
    public MalfunctionRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task AddJanitorsToMalfunction(Guid id, IEnumerable<Guid> janitorIds)
    {
        var malfunction = await Context.Malfunctions.FindAsync(id);

        foreach (var janitorId in janitorIds)
        {
            var janitor = await Context.Janitors.FindAsync(janitorId);

            if (janitor != null)
            {
                malfunction.Janitors.Add(janitor);
            }
        }

        await Context.SaveChangesAsync();
    }
}
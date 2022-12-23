using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;

namespace DormManagementSystem.DAL.Repositories.Implementations;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationContext context) : base(context)
    {
    }
}

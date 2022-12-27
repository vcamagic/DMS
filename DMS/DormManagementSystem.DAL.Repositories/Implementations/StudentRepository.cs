using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;

namespace DormManagementSystem.DAL.Repositories.Implementations;

public class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
    public StudentRepository(ApplicationContext context) : base(context)
    {
    }
}

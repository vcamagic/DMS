using System.Linq.Expressions;
using DormManagementSystem.DAL.Models;

namespace DormManagementSystem.DAL.Repositories.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    void Create(T entity);
    void CreateRange(IEnumerable<T> entities);
    void Update(T entity);
    void Delete(T entity);

    ApplicationContext Context { get; }
}

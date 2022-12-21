using System.Linq.Expressions;
using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.DAL.Repositories.Implementations;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    public ApplicationContext Context => _context;

    public RepositoryBase(ApplicationContext context)
    {
        _context = context;
    }
    public void Create(T entity) => _context.Set<T>().Add(entity);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public IQueryable<T> FindAll(bool trackChanges) =>
        trackChanges ? 
            _context.Set<T>().AsQueryable() :
            _context.Set<T>().AsNoTracking().AsQueryable();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        trackChanges ?
            _context.Set<T>().Where(expression).AsQueryable() :
            _context.Set<T>().AsNoTracking().Where(expression).AsQueryable();

    public void Update(T entity) => _context.Set<T>().Update(entity);

    
    private readonly ApplicationContext _context;
}

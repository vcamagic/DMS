using System.Linq.Expressions;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.BLL.Services.Implementations;

public class ServiceBase<T> : IServiceBase<T> where T : class
{
    public ServiceBase(IRepositoryBase<T> repository)
    {
        _repository = repository;
    }

    public IRepositoryBase<T> Repository => _repository;

    public async Task<IReadOnlyList<T>> GetEntityPage(PaginationDTO paginationDTO, bool trackChanges, params Expression<Func<T, object>>[] includes) =>
         await includes
                .Aggregate(_repository.FindAll(trackChanges), (current, include) => current.Include(include))
                .Skip((paginationDTO.Page - 1) * paginationDTO.PageSize)
                .Take(paginationDTO.PageSize)
                .ToListAsync();
    public async Task<T?> GetEntity(Expression<Func<T, bool>> expression, bool trackChanges, params Expression<Func<T, object>>[] includes) =>
        await includes
                .Aggregate(_repository.FindByCondition(expression, trackChanges), (current, include) => current.Include(include))
                .FirstOrDefaultAsync();

    public async Task Create(T entity)
    {
        _repository.Create(entity);

        await _repository.Context.SaveChangesAsync();
    }
    public async Task Update(T entity)
    {
        _repository.Update(entity);

        await _repository.Context.SaveChangesAsync();
    }
    public async Task Delete(T entity)
    {
        _repository.Delete(entity);

        await _repository.Context.SaveChangesAsync();
    }   

    private readonly IRepositoryBase<T> _repository;
}

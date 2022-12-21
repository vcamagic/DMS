using System.Linq.Expressions;
using DormManagementSystem.BLL.Services.DTOs;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IServiceBase<T> where T : class
{
    Task<IReadOnlyList<T>> GetEntityPage(PaginationDTO paginationDTO, bool trackChanges, params Expression<Func<T, object>>[] includes);
    Task<T?> GetEntity(Expression<Func<T, bool>> expression, bool trackChanges, params Expression<Func<T, object>>[] includes);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
using System.Linq.Expressions;
using DormManagementSystem.BLL.Services.DTOs;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IServiceBase<T> where T : class
{
    Task<Page<T>> GetEntityPage(PaginationDTO paginationDTO, bool trackChanges, string[] includes = null);
    Task<Page<T>> GetEntityPage(PaginationDTO paginationDTO, Expression<Func<T, bool>> expression, bool trackChanges, string[] includes = null);
    Task<T> GetEntity(Expression<Func<T, bool>> expression, bool trackChanges, string[] includes = null);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
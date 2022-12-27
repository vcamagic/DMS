using System.Linq.Expressions;
using DormManagementSystem.BLL.Services.DTOs;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IServiceBase<T> where T : class
{
    ///<summary>
    /// Gets a entity T page.
    ///</summary>
    ///<param name="paginationDTO">Specifies a page to be retrieved.</param>
    ///<param name="trackChanges">Will the changes to fetched entities be tracked.</param>
    ///<param name="includes">Related entities to be included in the query.</param>
    ///<param name="orderSelector">An expression that returns a property that will be used in sorting.</param>
    ///<param name="orderAscending">Flag for indicating kind of ordering.</param>
    ///<returns>Page of T entity.</returns>
    Task<Page<T>> GetEntityPage(PaginationDTO paginationDTO,
        bool trackChanges,
        string[] includes = null,
        Expression<Func<T, object>> orderSelector = null,
        bool orderAscending = true);

    ///<summary>
    /// Gets a Page of T entities that satisfy the <paramref name="expression"></paramref> provided.
    ///</summary>
    ///<param name="paginationDTO">Specifies a page to be retrieved.</param>
    ///<param name="expression">Expression to be evaluated against entities.</param>
    ///<param name="trackChanges">Will the changes to fetched entities be tracked.</param>
    ///<param name="includes">Related entities to be included in the query.</param>
    ///<returns>Page of T entity.</returns>
    Task<Page<T>> GetEntityPage(
        PaginationDTO paginationDTO,
        Expression<Func<T, bool>> expression,
        bool trackChanges,
        string[] includes = null, 
        Expression<Func<T, object>> orderSelector = null,
        bool orderAscending = true);

    ///<summary>
    /// Gets an entity of type T that satisfy the <paramref name="expression"></paramref> provided.
    ///</summary>
    ///<param name="expression">Expression to retrieve an entity.</param>
    ///<param name="trackChanges">Will the changes to fetched entity be tracked.</param>
    ///<param name="includes">Related entities to be included in the query.</param>
    ///<returns>Entity of type T.</returns>
    Task<T> GetEntity(Expression<Func<T, bool>> expression, bool trackChanges, string[] includes = null);

    ///<summary>
    /// Creates an entity of type T.
    ///</summary>
    ///<param name="entity">Entity of type T.</param>
    Task Create(T entity);

    ///<summary>
    /// Updates an entity of type T.
    ///</summary>
    ///<param name="entity">Entity of type T.</param>
    Task Update(T entity);

    ///<summary>
    /// Deletes an entity of type T.
    ///</summary>
    ///<param name="entity">Entity of type T.</param>
    Task Delete(T entity);
}
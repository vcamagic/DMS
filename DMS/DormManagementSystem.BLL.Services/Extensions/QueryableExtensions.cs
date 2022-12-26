using System.Linq.Expressions;
using DormManagementSystem.BLL.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.BLL.Services.Extensions;

public static class QueryableExtensions
{

    public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, Expression<Func<T, object>> orderSelector = null, bool orderAscending = true) where T : class
    {
        if (orderSelector != null)
        {
            return orderAscending == true ? query.OrderBy(orderSelector) : query.OrderByDescending(orderSelector);
        }

        return query;
    }

    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, PaginationDTO paginationDTO) where T : class
    {
        return query.Skip((paginationDTO.Page - 1) * paginationDTO.PageSize).Take(paginationDTO.PageSize);
    }


    public static IQueryable<T> LoadRelatedEntities<T>(this IQueryable<T> query, string[] includes = null) where T : class
    {
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return query;
    }
}

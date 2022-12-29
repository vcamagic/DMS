using System.Linq.Expressions;
using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Extensions;
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
    public ServiceBase(IRepositoryBase<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ServiceBase(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public ServiceBase(IRepositoryBase<T> repository, IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repository = repository;
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public IRepositoryBase<T> Repository => _repository;
    public IRepositoryManager RepositoryManager => _repositoryManager;
    public IMapper Mapper => _mapper;

    public async Task<IReadOnlyList<T>> GetEntities(bool trackChanges = false, Expression<Func<T, bool>> expression = null, string[] includes = null)
    {
        var query = expression switch
        {
            not null => _repository.FindByCondition(expression, trackChanges),
            _ => _repository.FindAll(trackChanges)
        };

        if (includes != null && !includes.Any(x => String.IsNullOrWhiteSpace(x)))
        {
            query =  includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return await query.ToListAsync();
    }

    public async Task<Page<T>> GetEntityPage(
        PaginationDTO paginationDTO,
        bool trackChanges,
        string[] includes = null,
        Expression<Func<T, object>> orderSelector = null,
        bool orderAscending = true)
    {
        var query = _repository.FindAll(trackChanges);
        return await ApplySortingPagingAndLoadRelatedEntities(query, paginationDTO, includes, orderSelector, orderAscending);
    }

    public async Task<Page<T>> GetEntityPage(
        PaginationDTO paginationDTO,
        Expression<Func<T, bool>> expression,
        bool trackChanges,
        string[] includes = null,
        Expression<Func<T, object>> orderSelector = null,
        bool orderAscending = true)
    {
        var query = _repository.FindByCondition(expression, trackChanges);
        return await ApplySortingPagingAndLoadRelatedEntities(query, paginationDTO, includes, orderSelector, orderAscending);
    }


    public async Task<T> GetEntity(Expression<Func<T, bool>> expression, bool trackChanges, string[] includes = null)
    {
        var query = _repository
            .FindByCondition(expression, trackChanges)
            .LoadRelatedEntities(includes);

        return await query.FirstOrDefaultAsync();
    }

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

    private async Task<Page<T>> ApplySortingPagingAndLoadRelatedEntities(
        IQueryable<T> query,
        PaginationDTO paginationDTO,
        string[] includes = null,
        Expression<Func<T, object>> orderSelector = null,
        bool orderAscending = true)
    {
        var entitiesCount = query.Count();

        var records = await query
            .ApplySorting(orderSelector, orderAscending)
            .ApplyPaging(paginationDTO)
            .LoadRelatedEntities(includes)
            .ToListAsync();


        var totalPages = (int)(entitiesCount / paginationDTO.PageSize) == 0 ? 1 : (int)(entitiesCount / paginationDTO.PageSize);

        return new Page<T>
        {
            TotalPages = totalPages,
            CurrentPage = paginationDTO.Page,
            Records = records
        };
    }

    private readonly IRepositoryBase<T> _repository;
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
}

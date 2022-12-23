using System.Linq.Expressions;
using AutoMapper;
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

    public async Task<Page<T>> GetEntityPage(PaginationDTO paginationDTO, bool trackChanges, string[] includes = null)
    {
        var query = _repository.FindAll(trackChanges);

        var records = await includes
                .Aggregate(query, (current, include) => current.Include(include))
                .Skip((paginationDTO.Page - 1) * paginationDTO.PageSize)
                .Take(paginationDTO.PageSize)
                .ToListAsync();

        return new Page<T>
        {
            TotalPages = (int)(query.Count() / paginationDTO.PageSize) == 0 ? 1 : (int)(query.Count() / paginationDTO.PageSize),
            CurrentPage = paginationDTO.Page,
            Records = records
        };
    }

    public async Task<Page<T>> GetEntityPage(
        PaginationDTO paginationDTO,
        Expression<Func<T, bool>> expression,
        bool trackChanges,
        string[] includes = null)
    {
        var query = _repository.FindByCondition(expression, trackChanges);

        var records = await includes
               .Aggregate(query, (current, include) => current.Include(include))
               .Skip((paginationDTO.Page - 1) * paginationDTO.PageSize)
               .Take(paginationDTO.PageSize)
               .ToListAsync();

        return new Page<T>
        {
            TotalPages = (int)(query.Count() / paginationDTO.PageSize) == 0 ? 1 : (int)(query.Count() / paginationDTO.PageSize),
            CurrentPage = paginationDTO.Page,
            Records = records
        };
    }


    public async Task<T> GetEntity(Expression<Func<T, bool>> expression, bool trackChanges, string[] includes = null) =>
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
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
}

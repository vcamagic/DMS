using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.BLL.Services.Implementations;

public class MalfunctionsService : ServiceBase<Malfunction>, IMalfunctionsService
{
    public MalfunctionsService(
        IRepositoryBase<Malfunction> repository,
        IRepositoryManager repositoryManager,
        IMapper mapper) : base(repository, repositoryManager, mapper)
    {
    }

    public async Task<MalfunctionDTO> GetMalfunction(Guid id)
    {
        var malfunction = await GetEntity(x => x.Id == id, false);
        return Mapper.Map<MalfunctionDTO>(malfunction);
    }

    public async Task<Page<MalfunctionDTO>> GetMalfunctions(PaginationDTO paginationDTO, SortDTO sortDTO, bool? resolved = null)
    {
        var malfunctionsPage = sortDTO switch
        {
            { SortBy: "priority" } =>  await GetEntityPage(paginationDTO, false, orderSelector: x => x.Priority, orderAscending: sortDTO.Order != "desc"),
            { SortBy: "expectedFixTime" } =>  await GetEntityPage(paginationDTO, false, orderSelector: x => x.ExpectedFixTime, orderAscending: sortDTO.Order != "desc"),
            { SortBy: "actualFixTime" } =>  await GetEntityPage(paginationDTO, false, orderSelector: x => x.ActualFixTime, orderAscending: sortDTO.Order != "desc"),
            _ => await GetEntityPage(paginationDTO, false)
        };

        return Mapper.Map<Page<MalfunctionDTO>>(malfunctionsPage);
    }

    public async Task<MalfunctionDTO> CreateMalfunction(CreateMalfunctionDTO createMalfunctionDTO)
    {
        var student = await RepositoryManager
            .StudentRepository
            .FindByCondition(x => x.Id == createMalfunctionDTO.StudentId, false)
            .FirstOrDefaultAsync() ??
                throw new BadRequestException($"Student with id {createMalfunctionDTO.StudentId} does not exist.");

        var malfunction = Mapper.Map<Malfunction>(createMalfunctionDTO);
        malfunction.IsFixed = false;

        await Create(malfunction);

        return Mapper.Map<MalfunctionDTO>(malfunction);
    }
}

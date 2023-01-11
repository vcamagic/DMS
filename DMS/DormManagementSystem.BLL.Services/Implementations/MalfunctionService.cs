using System.Linq.Expressions;
using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Helpers;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.BLL.Services.Implementations;

public class MalfunctionsService : ServiceBase<Malfunction>, IMalfunctionsService
{
    public MalfunctionsService(
        IServiceBase<Student> studentsService,
        IRepositoryBase<Malfunction> repository,
        IMapper mapper) : base(repository, mapper)
    {
        _studentsService = studentsService;
    }

    public async Task<MalfunctionDTO> GetMalfunction(Guid id)
    {
        var malfunction = await GetEntity(
            expression: x => x.Id == id,
            trackChanges: false,
            includes: ServiceHelpers.Include($"{nameof(Malfunction.Janitors)}")) ??
             throw new NotFoundException($"Malfunction with id {id} does not exist.");

        return Mapper.Map<MalfunctionDTO>(malfunction);
    }

    public async Task<Page<MalfunctionDTO>> GetMalfunctions(PaginationDTO paginationDTO, SortDTO sortDTO, bool? resolved = null)
    {
        var malfunctionsPage = await GetEntityPage(
            paginationDTO: paginationDTO,
            trackChanges: false,
            expression: x => resolved == null || x.IsFixed == resolved,
            orderSelector: CreateOrderSelector(sortDTO.SortBy),
            orderAscending: sortDTO.Order != "desc",
            includes: ServiceHelpers.Include($"{nameof(Malfunction.Janitors)}"));


        return Mapper.Map<Page<MalfunctionDTO>>(malfunctionsPage);
    }

    public async Task<MalfunctionDTO> CreateMalfunction(CreateMalfunctionDTO createMalfunctionDTO)
    {
        var student = await _studentsService.GetEntity(x => x.Id == createMalfunctionDTO.StudentId, false) ??
            throw new NotFoundException($"Student with id {createMalfunctionDTO.StudentId} does not exist.");

        var malfunction = Mapper.Map<Malfunction>(createMalfunctionDTO);
        malfunction.IsFixed = false;

        await Create(malfunction);

        return Mapper.Map<MalfunctionDTO>(malfunction);
    }

    public async Task UpdateMalfunction(Guid id, JsonPatchDocument<UpdateMalfunctionDTO> patchDocument)
    {
        var malfunction = await GetEntity(x => x.Id == id, true, new string[] { $"{nameof(Malfunction.Janitors)}" }) ??
            throw new NotFoundException($"Malfunction with id {id} does not exist.");

        var malfunctionToPatch = Mapper.Map<UpdateMalfunctionDTO>(malfunction);

        patchDocument.ApplyTo(malfunctionToPatch);

        if (malfunctionToPatch.Janitors != null)
        {
            await RepositoryManager.MalfunctionRepository.AddJanitorsToMalfunction(id, malfunctionToPatch.Janitors);
        }

        Mapper.Map(malfunctionToPatch, malfunction);

        await Update(malfunction);
    }

    private Expression<Func<Malfunction, object>> CreateOrderSelector(string orderBy = null) =>
        orderBy switch
        {
            "priority" => x => x.Priority,
            "expectedFixTime" => x => x.ExpectedFixTime,
            "actualFixTime" => x => x.ActualFixTime,
            _ => null
        };

    private readonly IServiceBase<Student> _studentsService;
}

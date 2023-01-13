using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Helpers;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;

namespace DormManagementSystem.BLL.Services.Implementations;

public class ProgramsService : ServiceBase<Program>, IProgramsService
{
    public ProgramsService(IRepositoryBase<Program> repository, IMapper mapper,
        IServiceBase<WashingMachine> washingMachine) : base(repository, mapper)
    {
        _washingMachineService = washingMachine;
    }

    public async Task<IReadOnlyList<ResponseProgramDto>> GetPrograms(Guid washingMachineId)
    {
        _ = await _washingMachineService.GetEntity(x => x.Id == washingMachineId, false) ??
            throw new NotFoundException($"Washing machine with id {washingMachineId} does not exist");

        var programs = await GetEntities(expression: x => x.WashingMachineId == washingMachineId,
            includes: ServiceHelpers.Include($"{nameof(Program.WashingMachine)}"));

        return Mapper.Map<IReadOnlyList<ResponseProgramDto>>(programs);
    }

    public async Task<ResponseProgramDto> GetProgram(Guid washingMachineId, Guid programId)
    {
        _ = await _washingMachineService.GetEntity(x => x.Id == washingMachineId, false) ??
            throw new NotFoundException($"Washing machine with id {washingMachineId} does not exist");

        var program = await GetEntity(x => x.Id == programId, false,
            ServiceHelpers.Include($"{nameof(Program.WashingMachine)}"));

        return Mapper.Map<ResponseProgramDto>(program);
    }

    public async Task<ResponseProgramDto> CreateProgram(Guid washingMachineId, RequestProgramDto requestProgramDto)
    {
        _ = await _washingMachineService.GetEntity(x => x.Id == washingMachineId, false) ??
            throw new NotFoundException($"Washing machine with id {washingMachineId} does not exist");

        var program = Mapper.Map<Program>(requestProgramDto);
        program.Id = new Guid();
        program.WashingMachineId = washingMachineId;

        await Create(program);
        return Mapper.Map<ResponseProgramDto>(program);
    }

    public async Task<ResponseProgramDto> UpdateProgram(Guid washingMachineId, Guid id,
        RequestProgramDto requestProgramDto)
    {
        _ = await _washingMachineService.GetEntity(x => x.Id == washingMachineId, false) ??
            throw new NotFoundException($"Washing machine with id {washingMachineId} does not exist");

        var program = Mapper.Map<Program>(requestProgramDto);
        program.WashingMachineId = washingMachineId;

        await Update(program);
        return Mapper.Map<ResponseProgramDto>(program);
    }

    private readonly IServiceBase<WashingMachine> _washingMachineService;
}
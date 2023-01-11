using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;

namespace DormManagementSystem.BLL.Services.Implementations;

public class WashingMachinesService : ServiceBase<WashingMachine>, IWashingMachinesService
{
    public WashingMachinesService(
        IServiceBase<Laundry> laundryService,
        IRepositoryBase<WashingMachine> repository,
        IMapper mapper) : base(repository, mapper)
    {
        _laundryService = laundryService;
    }

    public async Task<ResponseWashingMachineDTO> GetWashingMachine(Guid id)
    {
        var washingMachine = await GetEntity(x => x.Id == id, false) ??
             throw new NotFoundException($"Washing machine with id {id} does not exist.");

        return Mapper.Map<ResponseWashingMachineDTO>(washingMachine);
    }

    public async Task<IReadOnlyList<ResponseWashingMachineDTO>> GetWashingMachines()
    {
        var washingMachines = await GetEntities();
        return Mapper.Map<IReadOnlyList<ResponseWashingMachineDTO>>(washingMachines);
    }

    public async Task<ResponseWashingMachineDTO> CreateWashingMachine(RequestWashingMachineDTO createWashingMachineDTO)
    {
        _ = _laundryService.GetEntity(x => x.Id == createWashingMachineDTO.LaundryId, false) ??
            throw new NotFoundException($"Laundry room with id {createWashingMachineDTO.LaundryId} does not exist.");

        var washingMachine = Mapper.Map<WashingMachine>(createWashingMachineDTO);
        washingMachine.Id = Guid.NewGuid();

        await Create(washingMachine);

        return Mapper.Map<ResponseWashingMachineDTO>(washingMachine);
    }

    public async Task<ResponseWashingMachineDTO> UpdateWashingMachine(Guid id, RequestWashingMachineDTO createWashingMachineDTO)
    {
        var washingMachine = await GetEntity(x => x.Id == id, true) ??
            throw new NotFoundException($"Washing machine with id {id} does not exist.");

        _ = await _laundryService.GetEntity(x => x.Id == createWashingMachineDTO.LaundryId, false) ??
            throw new NotFoundException($"Laundry room with id {createWashingMachineDTO.LaundryId} does not exist.");

        Mapper.Map(createWashingMachineDTO, washingMachine);
        await Update(washingMachine);

        return Mapper.Map<ResponseWashingMachineDTO>(washingMachine);
    }

    public async Task DeleteWashingMachine(Guid id)
    {
        var washingMachine = await GetEntity(x => x.Id == id, true) ??
            throw new NotFoundException($"Washing machine with id {id} does not exist.");

        await Delete(washingMachine);
    }

    private readonly IServiceBase<Laundry> _laundryService;
}

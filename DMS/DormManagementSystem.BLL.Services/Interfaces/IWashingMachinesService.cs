using DormManagementSystem.BLL.Services.DTOs;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IWashingMachinesService
{
    Task<IReadOnlyList<ResponseWashingMachineDTO>> GetWashingMachines();
    Task<ResponseWashingMachineDTO> GetWashingMachine(Guid id);
    Task<ResponseWashingMachineDTO> CreateWashingMachine(RequestWashingMachineDTO createWashingMachineDTO);
    Task<ResponseWashingMachineDTO> UpdateWashingMachine(Guid id, RequestWashingMachineDTO createWashingMachineDTO);
    Task DeleteWashingMachine(Guid id);
}
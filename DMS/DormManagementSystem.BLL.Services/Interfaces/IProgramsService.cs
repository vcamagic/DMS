using DormManagementSystem.BLL.Services.DTOs;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IProgramsService
{
    Task<IReadOnlyList<ResponseProgramDto>> GetPrograms(Guid washingMachineId);
    Task<ResponseProgramDto> GetProgram(Guid washingMachineId, Guid programId);
    Task<ResponseProgramDto> CreateProgram(Guid washingMachineId, RequestProgramDto requestProgramDto);
    Task<ResponseProgramDto> UpdateProgram(Guid washingMachineId, Guid id, RequestProgramDto requestProgramDto);
}
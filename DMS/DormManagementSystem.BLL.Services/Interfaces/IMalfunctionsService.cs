using DormManagementSystem.BLL.Services.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IMalfunctionsService
{
    Task<Page<MalfunctionDTO>> GetMalfunctions(PaginationDTO paginationDTO, SortDTO sortDTO, bool? resolved = null);
    Task<MalfunctionDTO> GetMalfunction(Guid id);
    Task<MalfunctionDTO> CreateMalfunction(CreateMalfunctionDTO createMalfunctionDTO);
    Task UpdateMalfunction(Guid id, JsonPatchDocument<UpdateMalfunctionDTO> patchDocument);
}

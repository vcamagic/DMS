using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IShiftsService
{
    Task<ShiftDTO> GetShift(Guid id);
    Task<Page<ShiftDTO>> GetShifts(PaginationDTO paginationDTO);
    Task<ShiftDTO> CreateShift(CreateShiftDTO createShiftDTO);
    Task<ShiftDTO> UpdateShift(Guid id, UpdateShiftDTO updateShiftDTO);
    Task DeleteShift(Guid id);
}

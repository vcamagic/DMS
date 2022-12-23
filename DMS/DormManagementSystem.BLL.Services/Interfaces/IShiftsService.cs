using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IShiftsService : IServiceBase<Shift>
{
    Task<ShiftDTO> GetShift(Guid id);
    Task<ShiftDTO> CreateShift(CreateShiftDTO createShiftDTO);
}

using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.BLL.Services.Implementations;

public class ShiftsService : ServiceBase<Shift>, IShiftsService
{
    public ShiftsService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager.ShiftRepository, repositoryManager, mapper)
    {
    }

    public async Task<ShiftDTO> CreateShift(CreateShiftDTO createShiftDTO)
    {
        if (createShiftDTO.End <= createShiftDTO.Start)
        {
            throw new BadRequestException($"End of the shift must be after the start of the shift.");
        }

        var shift = Mapper.Map<Shift>(createShiftDTO);

        foreach (var employeeId in createShiftDTO.EmployeesIds)
        {
            var employee = RepositoryManager
                .EmployeeRepository
                .FindByCondition(x => x.Id == employeeId, true)
                .FirstOrDefault() ??
                    throw new BadRequestException($"Employee with id {employeeId} does not exist.");

            shift.Employees.Add(employee);
        }

        await Create(shift);

        return Mapper.Map<ShiftDTO>(shift);
    }

    public async Task<ShiftDTO> GetShift(Guid id)
    {
        var shift = await RepositoryManager
            .ShiftRepository
            .FindByCondition(x => x.Id == id, false)
            .Include(x => x.Employees)
            .ThenInclude(x => x.Account)
            .ThenInclude(x => x.Claims)
            .FirstOrDefaultAsync();

        return Mapper.Map<ShiftDTO>(shift);
    }
}

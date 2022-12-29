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
    public ShiftsService(
        IRepositoryManager repositoryManager,
        IMapper mapper) : base(repositoryManager.ShiftRepository, repositoryManager, mapper)
    {
    }

    public async Task<ShiftDTO> CreateShift(CreateShiftDTO createShiftDTO)
    {
        if (createShiftDTO.End <= createShiftDTO.Start)
        {
            throw new BadRequestException($"End of the shift must be after the start of the shift.");
        }

        var shift = Mapper.Map<Shift>(createShiftDTO);

        AddEmployeesToShift(createShiftDTO.EmployeesIds, shift.Employees);

        await Create(shift);

        return Mapper.Map<ShiftDTO>(shift);
    }

    public async Task DeleteShift(Guid id)
    {
        var shift = await GetEntity(x => x.Id == id, true) ??
            throw new BadRequestException($"Shift with id {id} does not exist.");

        await Delete(shift);
    }

    public async Task<ShiftDTO> GetShift(Guid id)
    {
        var shift = await GetEntity(
            x => x.Id == id,
            false,
            new string[] { $"{nameof(Shift.Employees)}.{nameof(Account)}" })
            ?? throw new BadRequestException($"Shift with id {id} does not exist.");

        return Mapper.Map<ShiftDTO>(shift);
    }

    public async Task<Page<ShiftDTO>> GetShifts(PaginationDTO paginationDTO)
    {
        var shifts = await GetEntityPage(paginationDTO, false, new string[] { $"{nameof(Shift.Employees)}.{nameof(Account)}" });

        return Mapper.Map<Page<ShiftDTO>>(shifts);
    }

    public async Task<ShiftDTO> UpdateShift(Guid id, UpdateShiftDTO updateShiftDTO)
    {
        var shift = await GetEntity(
            x => x.Id == id,
            true,
            new string[] { $"{nameof(Shift.Employees)}.{nameof(Account)}.{nameof(Account)}" }) ??
            throw new BadRequestException($"Shift with id {id} does not exist.");

        Mapper.Map(updateShiftDTO, shift);

        AddEmployeesToShift(updateShiftDTO.EmployeesIds, shift.Employees);

        await Update(shift);

        return Mapper.Map<ShiftDTO>(shift);
    }

    private void AddEmployeesToShift(IEnumerable<Guid> employeesIds, ICollection<Employee> employees)
    {
        foreach (var employeeId in employeesIds)
        {
            var employee = RepositoryManager
                .EmployeeRepository
                .FindByCondition(x => x.Id == employeeId, true)
                .FirstOrDefault() ??
                    throw new BadRequestException($"Employee with id {employeeId} does not exist.");

            employees.Add(employee);
        }
    }
}

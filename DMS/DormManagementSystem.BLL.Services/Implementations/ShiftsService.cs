using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Helpers;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;

namespace DormManagementSystem.BLL.Services.Implementations;

public class ShiftsService : ServiceBase<Shift>, IShiftsService
{
    public ShiftsService(
        IServiceBase<Employee> employeesService,
        IRepositoryManager repositoryManager,
        IMapper mapper) : base(repositoryManager.ShiftRepository, mapper)
    {
        _employeesService = employeesService;
    }

    public async Task<ShiftDTO> CreateShift(CreateShiftDTO createShiftDTO)
    {
        if (createShiftDTO.End <= createShiftDTO.Start)
        {
            throw new BadRequestException($"End of the shift must be after the start of the shift.");
        }

        var shift = Mapper.Map<Shift>(createShiftDTO);

        await AddEmployeesToShift(createShiftDTO.EmployeesIds, shift.Employees);

        await Create(shift);

        return Mapper.Map<ShiftDTO>(shift);
    }

    public async Task DeleteShift(Guid id)
    {
        var shift = await GetEntity(x => x.Id == id, true) ??
            throw new NotFoundException($"Shift with id {id} does not exist.");

        await Delete(shift);
    }

    public async Task<ShiftDTO> GetShift(Guid id)
    {
        var shift = await GetEntity(
            x => x.Id == id,
            false,
            ServiceHelpers.Include($"{nameof(Shift.Employees)}.{nameof(Account)}")
        ) ?? 
            throw new NotFoundException($"Shift with id {id} does not exist.");

        return Mapper.Map<ShiftDTO>(shift);
    }

    public async Task<Page<ShiftDTO>> GetShifts(PaginationDTO paginationDTO)
    {
        var shifts = await GetEntityPage(paginationDTO, false, includes: ServiceHelpers.Include($"{nameof(Shift.Employees)}.{nameof(Account)}"));

        return Mapper.Map<Page<ShiftDTO>>(shifts);
    }

    public async Task<ShiftDTO> UpdateShift(Guid id, UpdateShiftDTO updateShiftDTO)
    {
        var shift = await GetEntity(
            x => x.Id == id,
            true,
            ServiceHelpers.Include($"{nameof(Shift.Employees)}.{nameof(Account)}")
        ) ??
            throw new NotFoundException($"Shift with id {id} does not exist.");

        Mapper.Map(updateShiftDTO, shift);

        await AddEmployeesToShift(updateShiftDTO.EmployeesIds, shift.Employees);

        await Update(shift);

        return Mapper.Map<ShiftDTO>(shift);
    }

    private async Task AddEmployeesToShift(IEnumerable<Guid> employeesIds, ICollection<Employee> employees)
    {
        foreach (var employeeId in employeesIds)
        {
            var employee = await _employeesService.GetEntity(x => x.Id == employeeId, true) ??
                    throw new NotFoundException($"Employee with id {employeeId} does not exist.");

            employees.Add(employee);
        }
    }

    private readonly IServiceBase<Employee> _employeesService;
}

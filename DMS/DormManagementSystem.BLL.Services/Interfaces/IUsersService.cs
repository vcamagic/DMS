using DormManagementSystem.BLL.Services.DTOs;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IUsersService
{
    Task<Page<StudentDTO>> GetStudents(PaginationDTO paginationDTO);
    Task<IReadOnlyList<WardenDTO>> GetWardens();
    Task<IReadOnlyList<EmployeeDTO>> GetJanitors();
    Task<IReadOnlyList<EmployeeDTO>> GetMaids();
    Task<IReadOnlyList<EmployeeDTO>> GetDoorkeepers();
    Task<StudentDTO> GetStudent(Guid id);
    Task<WardenDTO> GetWarden(Guid id);
    Task<EmployeeDTO> GetJanitor(Guid id);
    Task<EmployeeDTO> GetMaid(Guid id);
    Task<EmployeeDTO> GetDoorkeeper(Guid id);
    Task<StudentDTO> CreateStudent(Guid accountId, CreateStudentDTO createStudentDTO);
    Task<WardenDTO> CreateWarden(Guid accountId, CreateWardenDTO createWardenDTO);
    Task<EmployeeDTO> CreateJanitor(Guid accountId, CreateJanitorDTO createJanitorDTO);
    Task<EmployeeDTO> CreateMaid(Guid accountId, CreateMaidDTO createMaidDTO);
    Task<EmployeeDTO> CreateDoorkeeper(Guid accountId, CreateDoorkeeperDTO createDoorkeeperDTO);
    Task<StudentDTO> UpdateStudent(Guid accountId, Guid id, UpdateStudentDTO updateStudentDTO);
    Task<WardenDTO> UpdateWarden(Guid accountId, Guid id, UpdateWardenDTO updateWardenDTO);
    Task<EmployeeDTO> UpdateMaid(Guid accountId, Guid id, UpdateMaidDTO updateMaidDTO);
    Task<EmployeeDTO> UpdateJanitor(Guid accountId, Guid id, UpdateJanitorDTO updateJanitorDTO);
    Task<EmployeeDTO> UpdateDoorkeeper(Guid accountId, Guid id, UpdateDoorkeeperDTO updateDoorkeeperDTO);
}

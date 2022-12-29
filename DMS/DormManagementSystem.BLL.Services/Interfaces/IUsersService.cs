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
    Task<StudentDTO> CreateStudent(CreateStudentDTO createStudentDTO);
    Task<WardenDTO> CreateWarden(CreateWardenDTO createWardenDTO);
    Task<EmployeeDTO> CreateJanitor(CreateJanitorDTO createJanitorDTO);
    Task<EmployeeDTO> CreateMaid(CreateMaidDTO createMaidDTO);
    Task<EmployeeDTO> CreateDoorkeeper(CreateDoorkeeperDTO createDoorkeeperDTO);
    Task<StudentDTO> UpdateStudent(Guid id, UpdateStudentDTO updateStudentDTO);
    Task<WardenDTO> UpdateWarden(Guid id, UpdateWardenDTO updateWardenDTO);
    Task<EmployeeDTO> UpdateMaid(Guid id, UpdateMaidDTO updateMaidDTO);
    Task<EmployeeDTO> UpdateJanitor(Guid id, UpdateJanitorDTO updateJanitorDTO);
    Task<EmployeeDTO> UpdateDoorkeeper(Guid id, UpdateDoorkeeperDTO updateDoorkeeperDTO);
}

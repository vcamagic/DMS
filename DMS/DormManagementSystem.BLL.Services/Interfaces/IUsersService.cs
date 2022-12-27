using DormManagementSystem.BLL.Services.DTOs;

namespace DormManagementSystem.BLL.Services.Interfaces;

public interface IUsersService
{
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
}

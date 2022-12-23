using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.DTOs;

public class CreateShiftDTO
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public ICollection<Guid> EmployeesIds { get; set; }
}

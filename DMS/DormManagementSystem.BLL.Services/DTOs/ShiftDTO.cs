using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.BLL.Services.DTOs;

public class ShiftDTO
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = $"{nameof(Start)} is required.")]
    public DateTime Start { get; set; }
    [Required(ErrorMessage = $"{nameof(End)} is required.")]
    public DateTime End { get; set; }

    public IReadOnlyList<EmployeeDTO> Employees {get; set;}
}

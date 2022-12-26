using System.ComponentModel.DataAnnotations;
using DormManagementSystem.BLL.Services.CustomValidationAttributes;

namespace DormManagementSystem.BLL.Services.DTOs;

public class UpdateShiftDTO
{
    [Required]
    [DateAfter(FirstDateProperty = nameof(End), SecondDateProperty = nameof(Start), ErrorMessage = "End date must be after start date.")]
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "Must contain at least one employee id.")]
    public ICollection<Guid> EmployeesIds { get; set; }
}
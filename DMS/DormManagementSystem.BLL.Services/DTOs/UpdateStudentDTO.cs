using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.BLL.Services.DTOs;

public class UpdateStudentDTO : UpdateUserDTO
{
    [Required(ErrorMessage = $"{nameof(FacultyName)} is required."), MaxLength(50, ErrorMessage = $"{nameof(FacultyName)} is required.")]
    public string FacultyName { get; set; }
    [Required(ErrorMessage = $"{nameof(IndexNumber)} is required.")]
    public string IndexNumber { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DormManagementSystem.DAL.Models.Models;

[Table("Students")]
public class Student : User
{
    [Required(ErrorMessage = $"{nameof(FacultyName)} is required.")]
    [MaxLength(50, ErrorMessage = $"{nameof(FacultyName)} can be 50 characters max.")]
    public string FacultyName { get; set; }
    [Required(ErrorMessage = $"{nameof(IndexNumber)} is required.")]
    [MaxLength(10, ErrorMessage = $"{nameof(IndexNumber)} can be 10 characters max.")]
    public string IndexNumber { get; set; }

    public ICollection<Malfunction> Malfunctions { get; set; }
}

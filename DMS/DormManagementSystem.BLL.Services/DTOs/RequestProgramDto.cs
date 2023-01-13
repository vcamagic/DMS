using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.BLL.Services.DTOs;

public class RequestProgramDto
{
    [MaxLength(50, ErrorMessage = $"{nameof(Name)} max length is 50 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = $"{nameof(Temperature)} is required"),
     Range(0, int.MaxValue, ErrorMessage = $"{nameof(Temperature)} must be a positive value")]

    public int? Temperature { get; set; }

    [Required(ErrorMessage = $"{nameof(Duration)} is required"),
     Range(0, float.MaxValue, ErrorMessage = $"{nameof(Duration)} must be a positive value")]
    public float? Duration { get; set; }
}
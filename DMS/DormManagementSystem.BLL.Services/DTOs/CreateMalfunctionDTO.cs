using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.BLL.Services.DTOs;

public class CreateMalfunctionDTO
{
    [MaxLength(250, ErrorMessage = $"{nameof(Description)} max length is 250 characters.")]
    public string Description { get; set; }
    [Required(ErrorMessage = $"{nameof(Priority)} is required."), Range(0, 5, ErrorMessage = $"{nameof(Priority)} is a number between 0 and 5.")]
    public int Priority { get; set; }

    [Required(ErrorMessage = $"{nameof(StudentId)} is required.")]
    public Guid StudentId { get; set; }
    public Guid RoomId { get; set; }
}

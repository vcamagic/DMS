using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.BLL.Services.DTOs;

public class UpdateMalfunctionDTO
{
    [MaxLength(250, ErrorMessage = $"{nameof(Description)} max length is 250 characters.")]
    public string Description { get; set; }
    [Range(0, 5, ErrorMessage = $"{nameof(Priority)} is a number between 0 and 5.")]
    public int? Priority { get; set; }
    public DateTime? ExpectedFixTime { get; set; }
    public DateTime? ActualFixTime { get; set; }
    public bool? IsFixed { get; set; }

    public ICollection<Guid> Janitors {get; set;}
}
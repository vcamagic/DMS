namespace DormManagementSystem.BLL.Services.DTOs;

public class MalfunctionDTO
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    public bool IsFixed { get; set; }
    public Guid StudentId { get; set; }
}

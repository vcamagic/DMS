namespace DormManagementSystem.BLL.Services.DTOs;

public class MalfunctionDTO
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    public bool IsFixed { get; set; }
    public DateTime? ExpectedFixTime { get; set; }
    public DateTime? ActualFixTime { get; set; }
    public Guid StudentId { get; set; }
    public IReadOnlyList<Guid> Janitors { get; set; }
}

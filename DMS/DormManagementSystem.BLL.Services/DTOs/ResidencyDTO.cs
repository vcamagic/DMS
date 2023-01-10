namespace DormManagementSystem.BLL.Services.DTOs;

public class ResidencyDTO : RoomDTO
{
    public int Capacity { get; set; }
    public override string RoomType { get; set; } = "Residency";
}
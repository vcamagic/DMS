namespace DormManagementSystem.BLL.Services.DTOs;

public class LaundryDTO : RoomDTO
{
    public int Capacity { get; set; }
    public override string RoomType { get; set; } = "Laundry";
}
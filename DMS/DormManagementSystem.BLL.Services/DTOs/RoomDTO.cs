namespace DormManagementSystem.BLL.Services.DTOs;

public class RoomDTO
{
    public string RoomNumber { get; set; }
    public int Capacity { get; set; }
    public RoomType Type { get; set; }
}

public enum RoomType
{
    Residency,
    Laundry,
    Entertainment,
    Other
}
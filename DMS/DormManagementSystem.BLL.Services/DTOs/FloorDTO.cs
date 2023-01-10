namespace DormManagementSystem.BLL.Services.DTOs;

public class FloorDTO
{
    public int Level { get; set; }
    public IReadOnlyList<ResidencyDTO> Residencies { get; set; }
    public IReadOnlyList<LaundryDTO> Laundries { get; set; }
    public IReadOnlyList<EntertainmentDTO> Entertainments { get; set; }
}
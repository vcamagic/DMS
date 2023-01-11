namespace DormManagementSystem.BLL.Services.DTOs;

public class ResponseWashingMachineDTO
{
    public Guid Id { get; set; }
    public int KgCapacity { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public Guid LaundryId { get; set; }
}
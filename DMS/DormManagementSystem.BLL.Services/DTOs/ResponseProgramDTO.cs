namespace DormManagementSystem.BLL.Services.DTOs;

public class ResponseProgramDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Temperature { get; set; }
    public float Duration { get; set; }
    
    public Guid WashingMachineId { get; set; }
}
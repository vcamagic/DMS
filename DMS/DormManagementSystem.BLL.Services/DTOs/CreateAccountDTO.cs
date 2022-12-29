namespace DormManagementSystem.BLL.Services.DTOs;

public class CreateAccountDTO
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; } = false;
}

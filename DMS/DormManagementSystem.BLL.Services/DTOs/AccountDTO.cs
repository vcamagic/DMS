using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services.DTOs;

public class AccountDTO
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }  
}

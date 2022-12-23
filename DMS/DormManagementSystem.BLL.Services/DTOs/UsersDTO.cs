namespace DormManagementSystem.BLL.Services.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth  { get; set; }
    public string Address { get; set; }
    public string JMBG { get; set; }
    public AccountDTO Account { get; set; }
}

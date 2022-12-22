using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.DAL.Models.Models;

public class User
{
    public User()
    {
        Id = Guid.NewGuid();
    }

    [Key, Required(ErrorMessage = $"{nameof(Id)} is required.")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = $"{nameof(FirstName)} is required.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = $"{nameof(LastName)} is required.")]
    public string LastName { get; set; }
    [Required(ErrorMessage = $"{nameof(DateOfBirth)} is required.")]
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    [Required(ErrorMessage = $"{nameof(JMBG)} is required.")]
    public string JMBG { get; set; }
    [EnumDataType(typeof(SexEnum))]
    [Required(ErrorMessage = $"{nameof(Sex)} is required.")]
    public int Sex { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; }
}

public class SexEnum
{
    public const int Male = 1;
    public const int Female = 2;
}

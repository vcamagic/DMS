namespace DormManagementSystem.DAL.Models.Models;

public class Claim
{
    public Guid ClaimTypeId { get; set; }
    public ClaimType ClaimType { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; }
}

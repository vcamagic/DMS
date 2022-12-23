namespace DormManagementSystem.BLL.Services.DTOs;

public class Page<T> where T : class
{
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public IEnumerable<T> Records { get; set; }
}

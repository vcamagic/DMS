namespace DormManagementSystem.BLL.Services.DTOs;

public class PaginationDTO
{
    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = value > _maxPageSize ? _maxPageSize : value; }
    }
    public int Page { get => _page; set => _page = value; }

    private int _pageSize = 20;
    private int _page = 0;
    private int _maxPageSize = 50;

}

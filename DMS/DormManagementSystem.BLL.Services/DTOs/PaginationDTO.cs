using System.ComponentModel.DataAnnotations;

namespace DormManagementSystem.BLL.Services.DTOs;

public class PaginationDTO
{
    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = value > _maxPageSize ? _maxPageSize : value < 0 ? 1 : value; }
    }
    public int Page { get { return _page; } set { _page = value <= 0 ? 1 : value; }}

    private int _pageSize = 20;
    private int _page = 1;
    private int _maxPageSize = 50;

}

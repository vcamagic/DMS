namespace DormManagementSystem.BLL.Services.DTOs;

public class DormStructureBatch
{
    public IEnumerable<RoomDTO> Rooms { get; set; }
    public string NextToken { get; set; }
    public int Limit
    {
        get
        {
            return _maxLimit;
        }
        set
        {
            _maxLimit = value > 20 ? 20 : value;
        }
    }

    private int _maxLimit = 20;
}
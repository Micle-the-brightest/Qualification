namespace Dormitory.Services.Request.Dormitory;

public class CreateDormitoryRequest
{
    public string BuldingName { set; get; }
    public string Address { set; get; }
    public int PostIndex { set; get; }
    public int RoomCount { set; get; }
    public int PersonCount { set; get; }
    public int FreeBedCount { set; get; }  
}
namespace Dormitory.Services;

public class CreateRoomRequest
{
    public int Id { set; get; }
    public int NumRoom { set; get; }
    public int RoomCount { set; get; }
    public int PersonCount { set; get; }
    public int FreeBedCount { set; get; }
    public double RoomArea { set; get; }
    public string RoomSex { set; get; }
}
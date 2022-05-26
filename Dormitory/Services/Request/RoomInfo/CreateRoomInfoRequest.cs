
namespace Dormitory.Services;

public class CreateRoomInfoRequest
{
    public int Id { set; get; }
    public string StudName { set; get; }
    public int NumRoom { set; get; }
    public string TypeRoom { set; get; } //?
    public string Faculty { set; get; }
    public int CourseNum { set; get; }
    public string RoomSex { set; get; } //?
    public  DateTime DateOfSettlement { set; get; } 
    public  DateTime DateOfDeparture { set; get; } 
    public  DateTime EarlyDepartureDate { set; get; } 
}
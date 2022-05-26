namespace Dormitory.Mapper;

public class RoomInfoViewModel
{
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
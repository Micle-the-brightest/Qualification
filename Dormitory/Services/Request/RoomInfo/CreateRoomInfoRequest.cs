using System.ComponentModel.DataAnnotations;
namespace Dormitory.Services.Request.RoomInfo;



public class CreateRoomInfoRequest
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
    public int RoomId { set; get; } 
}
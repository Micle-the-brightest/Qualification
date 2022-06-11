
using System.ComponentModel.DataAnnotations;
namespace Dormitory.Mapper;


public class RoomInfoViewModel
{
    public int Id { set; get; }
    public string StudName { set; get; }
    public int NumRoom { set; get; }
    public string TypeRoom { set; get; } //?
    public string Faculty { set; get; }
    public int CourseNum { set; get; }
    public string RoomSex { set; get; } //?
    
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public  DateTime DateOfSettlement { set; get; } 
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public  DateTime DateOfDeparture { set; get; } 
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public  DateTime EarlyDepartureDate { set; get; } 
    public int RoomId { set; get; } 
}
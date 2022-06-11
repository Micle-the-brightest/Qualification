using Dormitory.Mapper;

namespace Dormitory.Services.Response.Room;

public class GetRoomResponse
{
    public IEnumerable<RoomViewModel> Rooms { get; set; }
        = new List<RoomViewModel>();
}

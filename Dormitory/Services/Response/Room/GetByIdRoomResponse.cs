using Dormitory.Mapper;

namespace Dormitory.Services.Response.Room;

public class GetByIdRoomResponse
{
    public RoomViewModel Room { get; set; }
        = new RoomViewModel();
}
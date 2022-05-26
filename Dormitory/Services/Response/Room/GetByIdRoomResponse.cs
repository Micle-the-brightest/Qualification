using Dormitory.Mapper;

namespace Dormitory.Services;

public class GetByIdRoomResponse
{
    public RoomViewModel Room { get; set; }
        = new RoomViewModel();
}
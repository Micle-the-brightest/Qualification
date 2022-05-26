using Dormitory.Mapper;

namespace Dormitory.Services;

public class GetRoomResponse
{
    public IEnumerable<RoomViewModel> Rooms { get; set; }
        = new List<RoomViewModel>();
}

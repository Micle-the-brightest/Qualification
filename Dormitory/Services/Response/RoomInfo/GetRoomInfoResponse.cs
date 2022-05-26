using Dormitory.Mapper;

namespace Dormitory.Services;

public class GetRoomInfoResponse
{
    public IEnumerable<RoomInfoViewModel> RoomsInfo { get; set; }
        = new List<RoomInfoViewModel>();
}
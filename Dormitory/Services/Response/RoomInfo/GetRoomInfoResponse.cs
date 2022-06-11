using Dormitory.Mapper;

namespace Dormitory.Services.Response.RoomInfo;

public class GetRoomInfoResponse
{
    public IEnumerable<RoomInfoViewModel> RoomsInfo { get; set; }
        = new List<RoomInfoViewModel>();
}
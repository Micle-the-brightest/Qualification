using Dormitory.Mapper;

namespace Dormitory.Services.Response.RoomInfo;

public class GetByIdRoomInfoResponse
{
    public RoomInfoViewModel RoomInfo { get; set; }
        = new RoomInfoViewModel();
}
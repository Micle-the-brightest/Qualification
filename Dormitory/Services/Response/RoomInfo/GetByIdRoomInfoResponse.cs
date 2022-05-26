using Dormitory.Mapper;

namespace Dormitory.Services;

public class GetByIdRoomInfoResponse
{
    public RoomInfoViewModel RoomInfo { get; set; }
        = new RoomInfoViewModel();
}
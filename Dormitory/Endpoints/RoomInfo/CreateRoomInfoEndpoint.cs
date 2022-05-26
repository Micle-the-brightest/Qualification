using Dormitory.Entityes;
using Dormitory.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Dormitory.Endpoints.RoomInfo;

[HttpPost("/roomInfo")][AllowAnonymous]
public class CreateRoomInfoEndpoint:Endpoint<CreateRoomInfoRequest, CreateRoomInfoResponse>
{
    private readonly DormitoryContext _roomInfoContext;
    
    public CreateRoomInfoEndpoint(DormitoryContext roomInfoContext)
    {
        _roomInfoContext = roomInfoContext;
    }

    public override async Task HandleAsync(CreateRoomInfoRequest req, CancellationToken ct)
    {
        var entity = new Entityes.RoomInfo
        {
            Id = req.Id,
            StudName = req.StudName,
            NumRoom = req.NumRoom,
            TypeRoom = req.TypeRoom,
            Faculty = req.Faculty,
            CourseNum = req.CourseNum,
            RoomSex = req.RoomSex,
            DateOfSettlement = req.DateOfSettlement,
            DateOfDeparture = req.DateOfDeparture,
            EarlyDepartureDate = req.EarlyDepartureDate,
        };
        await _roomInfoContext.AddAsync(entity, ct);
        await SendOkAsync(ct);
    }
}
using Dormitory.Entityes;
using Dormitory.Mapper;
using Dormitory.Services;
using Dormitory.Services.Request.RoomInfo;
using Dormitory.Services.Response.RoomInfo;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.RoomInfo;
[HttpGet("/roomInfo")][AllowAnonymous]
public class GetRoomInfoEndpoint: Endpoint<GetRoomInfoRequest, GetRoomInfoResponse>
{
    private readonly DormitoryContext _roomInfoContext;
    
    public GetRoomInfoEndpoint(DormitoryContext roomInfoContext)
    {
        _roomInfoContext = roomInfoContext;
    }
    
    public override async Task HandleAsync(GetRoomInfoRequest req, CancellationToken ct)
    {
        var entities = await _roomInfoContext.RoomsInfo.ToListAsync(ct);
        var response = new GetRoomInfoResponse()
        {
            RoomsInfo = entities.Select(f => new RoomInfoViewModel()
            {   
                Id = f.Id,
                StudName = f.StudName,
                NumRoom= f.NumRoom,
                Faculty= f.Faculty,
                CourseNum =f.CourseNum,
                RoomSex = f.RoomSex,
                DateOfSettlement= f.DateOfSettlement,
                DateOfDeparture =f.DateOfDeparture,
                EarlyDepartureDate = f.EarlyDepartureDate,
                RoomId = f.RoomId

            })
        };
        await SendAsync(response, cancellation: ct);

    }
    
    
}
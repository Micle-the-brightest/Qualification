using Dormitory.Entityes;
using Dormitory.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.RoomInfo;
[HttpPut("/roomInfo/{{id}}")][AllowAnonymous]
public class UpdateRoomInfoEndpoint:Endpoint<UpdateRoomInfoRequest, UpdateRoomInfoResponse>
{
    private readonly DormitoryContext _roomInfoContext; 
    private readonly ILogger<UpdateRoomInfoEndpoint> _logger;
    public UpdateRoomInfoEndpoint(DormitoryContext roomContext, ILogger<UpdateRoomInfoEndpoint> logger)
    {
        _roomInfoContext = roomContext;
        _logger = logger;
    }
    
    public override async Task HandleAsync(UpdateRoomInfoRequest req, CancellationToken ct)
    {
        var entity = await _roomInfoContext.RoomsInfo.FirstOrDefaultAsync(
            x=>x.Id == req.Id, cancellationToken: ct);
        
        if( entity is null)
        {
            _logger.LogInformation("RoomInfoItem not found by this Id");
            await SendNotFoundAsync(ct);
        }
        
        entity.StudName = req.StudName;
        entity.NumRoom = req.NumRoom;
        entity.TypeRoom = req.TypeRoom;
        entity.Faculty = req.Faculty;
        entity.CourseNum = req.CourseNum;
        entity.RoomSex = req.RoomSex;
        entity.DateOfSettlement = req.DateOfSettlement;
        entity.DateOfDeparture = req.DateOfDeparture;
        entity.EarlyDepartureDate = req.EarlyDepartureDate;
        

        _roomInfoContext.RoomsInfo.Update(entity);
        await _roomInfoContext.SaveChangesAsync(ct);
        await SendOkAsync(ct);

    }
    
}
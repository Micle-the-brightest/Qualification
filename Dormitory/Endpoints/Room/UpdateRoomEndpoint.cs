using Dormitory.Entityes;
using Dormitory.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.Room;

[HttpPut("/room/{{id}}")][AllowAnonymous]
public class UpdateRoomEndpoint :Endpoint<UpdateRoomRequest, UpdateRoomResponse>
{
    private readonly DormitoryContext _roomContext; 
    private readonly ILogger<UpdateRoomEndpoint> _logger;
    public UpdateRoomEndpoint(DormitoryContext roomContext, ILogger<UpdateRoomEndpoint> logger)
    {
        _roomContext = roomContext;
        _logger = logger;
    }
   
    public override async Task HandleAsync(UpdateRoomRequest req, CancellationToken ct)
    {
        var entity = await _roomContext.Rooms.FirstOrDefaultAsync(
            x=>x.Id == req.Id, cancellationToken: ct);
        
        if( entity is null)
        {
            _logger.LogInformation("RoomListItem not found by this Id");
            await SendNotFoundAsync(ct);
        }
        
        entity.NumRoom = req.NumRoom;
        entity.RoomCount = req.RoomCount;
        entity.PersonCount = req.PersonCount;
        entity.FreeBedCount = req.FreeBedCount;
        entity.RoomArea = req.RoomArea;
        entity.RoomSex = req.RoomSex;

        _roomContext.Rooms.Update(entity);
        await _roomContext.SaveChangesAsync(ct);
        await SendOkAsync(ct);

    }
    
}
using Dormitory.Entityes;
using Dormitory.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.Room;


[HttpDelete("/room/{{id}}")] [AllowAnonymous]
public class DeleteRoomEndpoint :Endpoint<DeleteRoomRequest, DeleteRoomResponse>
{
    private readonly DormitoryContext _roomContext; 
    private readonly ILogger<DeleteRoomEndpoint> _logger;

    public DeleteRoomEndpoint(DormitoryContext roomContext, ILogger<DeleteRoomEndpoint> logger)
    {
        _roomContext = roomContext;
        _logger = logger;
    }

    public override async Task HandleAsync(DeleteRoomRequest req, CancellationToken ct)
    {
        var entity = await _roomContext.Rooms.FirstOrDefaultAsync(
            x=>x.Id == req.Id, cancellationToken: ct);
        if( entity is null)
        {
            _logger.LogInformation("RoomItem not found by this Id");
            await SendNotFoundAsync(ct);
        }

        _roomContext.Rooms.Remove(entity);
        await _roomContext.SaveChangesAsync(ct);
        await SendOkAsync(ct);
    }
    
}
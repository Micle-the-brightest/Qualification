using Dormitory.Entityes;
using Dormitory.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.RoomInfo;

[HttpDelete("/roomInfo/{{id}}")] [AllowAnonymous]
public class DeleteRoomInfoEndpoint:Endpoint<DeleteRoomInfoRequest, DeleteRoomInfoResponse>
{
    private readonly DormitoryContext _roomInfoContext;
    private readonly ILogger<DeleteRoomInfoEndpoint> _logger;
    public DeleteRoomInfoEndpoint(DormitoryContext roomInfoContext, ILogger<DeleteRoomInfoEndpoint> logger)
    {
        _roomInfoContext = roomInfoContext;
        _logger = logger;
    }

    public override async Task HandleAsync(DeleteRoomInfoRequest req, CancellationToken ct)
    {
        var entity = await _roomInfoContext.RoomsInfo.FirstOrDefaultAsync(
            x=>x.Id == req.Id, cancellationToken: ct);
        if( entity is null)
        {
            _logger.LogInformation("RoomInfoItem not found by this Id");
            await SendNotFoundAsync(ct);
        }
        
        _roomInfoContext.RoomsInfo.Remove(entity);
        await _roomInfoContext.SaveChangesAsync(ct);
        await SendOkAsync(ct);
       
    }
    
}
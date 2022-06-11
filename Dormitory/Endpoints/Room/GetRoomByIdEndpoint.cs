using Dormitory.Entityes;
using Dormitory.Mapper;
using Dormitory.Services;
using Dormitory.Services.Request.Room;
using Dormitory.Services.Response.Room;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.Room;

[HttpGet("/room/{id}")][AllowAnonymous]
public class GetRoomByIdEndpoint: Endpoint<GetByIdRoomRequest, GetByIdRoomResponse>
{
    private readonly DormitoryContext _roomContext;
    private readonly ILogger<GetRoomByIdEndpoint> _logger;

    
    public GetRoomByIdEndpoint(DormitoryContext roomContext, ILogger<GetRoomByIdEndpoint> logger)
    {
        _roomContext = roomContext;
        _logger = logger;
    }
    
    
    public override async Task HandleAsync(GetByIdRoomRequest req, CancellationToken ct)
    {
        var entity = await _roomContext.Rooms.FirstOrDefaultAsync(
            x=>x.Id == req.Id, cancellationToken: ct);
        if( entity is null)
        {
            _logger.LogInformation("RoomItem not found by this Id");
            await SendNotFoundAsync(ct);
        }
        
        var response = new GetByIdRoomResponse
        {
            Room =  new RoomViewModel
            {   NumRoom = entity.NumRoom,
                RoomCount= entity.RoomCount,
                PersonCount= entity.PersonCount,
                FreeBedCount= entity.FreeBedCount,
                RoomArea = entity.RoomArea,
                RoomSex = entity.RoomSex
            }
        };
        await SendAsync(response, cancellation: ct);

    }
    
}
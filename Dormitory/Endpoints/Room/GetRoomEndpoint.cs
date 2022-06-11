using Dormitory.Entityes;
using Dormitory.Mapper;
using Dormitory.Services;
using Dormitory.Services.Request.Room;
using Dormitory.Services.Response.Room;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.Room;

[HttpGet("/room")][AllowAnonymous]
public class GetRoomEndpoint: Endpoint<GetRoomRequest, GetRoomResponse>
{
    private readonly DormitoryContext _roomContext;
    
    public GetRoomEndpoint(DormitoryContext roomContext)
    {
        _roomContext = roomContext;
    }
    
    public override async Task HandleAsync(GetRoomRequest req, CancellationToken ct)
    {
        var entities = await _roomContext.Rooms.ToListAsync(ct);
        var response = new GetRoomResponse()
        {
            Rooms = entities.Select(f => new RoomViewModel
            {
                Id =f.Id,
                NumRoom = f.NumRoom,
                RoomCount= f.RoomCount,
                PersonCount= f.PersonCount,
                FreeBedCount= f.FreeBedCount,
                RoomArea =f.RoomArea,
                RoomSex = f.RoomSex,
                DormitoryId =f.DormitoryId,
                TypeId = f.TypeId
                
            })
        };
        await SendAsync(response, cancellation: ct);

    }
    
}
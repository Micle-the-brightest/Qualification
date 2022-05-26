using Dormitory.Entityes;
using Dormitory.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Dormitory.Endpoints.Room;

[HttpPost("/room")][AllowAnonymous]
public class CreateRoomEndpoint :Endpoint<CreateRoomRequest, CreateDormitoryResponse>
{
    private readonly DormitoryContext _roomContext; // чи правильно тут вказувати DormitoryContext

    public CreateRoomEndpoint(DormitoryContext roomContext)
    {
        _roomContext = roomContext;
    }

    public override async Task HandleAsync(CreateRoomRequest req, CancellationToken ct)
    {
        var entity = new Entityes.Room
        {
            Id = req.Id,
            NumRoom = req.NumRoom,
            RoomCount = req.RoomCount,
            PersonCount = req.PersonCount,
            FreeBedCount = req.FreeBedCount,
            RoomArea = req.RoomArea,
            RoomSex = req.RoomSex
            
        };
        await _roomContext.AddAsync(entity, ct);
            await SendOkAsync(ct);
    }
}
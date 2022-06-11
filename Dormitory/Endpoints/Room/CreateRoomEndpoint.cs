using Dormitory.Entityes;
using Dormitory.Services;
using Dormitory.Services.Request.Room;
using Dormitory.Services.Response.Dormitory;
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
            NumRoom = req.NumRoom,
            RoomCount = req.RoomCount,
            PersonCount = req.PersonCount,
            FreeBedCount = req.FreeBedCount,
            RoomArea = req.RoomArea,
            RoomSex = req.RoomSex,
            DormitoryId =req.DormitoryId,
            TypeId = req.TypeId
            
        };
        await _roomContext.AddAsync(entity, ct);
        await _roomContext.SaveChangesAsync(ct); //додати у всі креейти
            await SendOkAsync(ct);
    }
}
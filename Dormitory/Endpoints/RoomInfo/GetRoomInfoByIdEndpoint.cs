using Dormitory.Entityes;
using Dormitory.Mapper;
using Dormitory.Services;
using Dormitory.Services.Request.RoomInfo;
using Dormitory.Services.Response.RoomInfo;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.RoomInfo;

[HttpGet("/roomInfo/{id}")][AllowAnonymous]
public class GetRoomInfoByIdEndpoint: Endpoint<GetByIdRoomInfoRequest, GetByIdRoomInfoResponse>
{
    private readonly DormitoryContext _roomInfoContext;
    private readonly ILogger<GetRoomInfoByIdEndpoint> _logger;
    public GetRoomInfoByIdEndpoint(DormitoryContext roomInfoContext, ILogger<GetRoomInfoByIdEndpoint> logger)
    {
        _roomInfoContext = roomInfoContext;
        _logger = logger;
    }
    
    public override async Task HandleAsync(GetByIdRoomInfoRequest req, CancellationToken ct)
    {
        var entity = await _roomInfoContext.RoomsInfo.FirstOrDefaultAsync(
            x=>x.Id == req.Id, cancellationToken: ct);
        if( entity is null)
        {
            _logger.LogInformation("RoomInfoItem not found by this Id");
            await SendNotFoundAsync(ct);
        }
        
        var response = new GetByIdRoomInfoResponse
        {
            RoomInfo =  new RoomInfoViewModel
            {  
                StudName= entity.StudName,
                NumRoom = entity.NumRoom,
                Faculty= entity.Faculty,
                CourseNum = entity.CourseNum,
                RoomSex = entity.RoomSex,
                DateOfSettlement= entity.DateOfSettlement,
                DateOfDeparture = entity.DateOfDeparture,
                EarlyDepartureDate = entity.EarlyDepartureDate,
                
            }
        };
        await SendAsync(response, cancellation: ct);

    }
    
}
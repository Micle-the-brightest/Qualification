using Dormitory.Entityes;
using Dormitory.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.Dormitories;

[HttpPut("/dormitory/{{id}}")][AllowAnonymous]
public class UpdateDormitoryEndpoint:Endpoint<UpdateDormitoryRequest, UpdateDormitoryResponse>
{
    private readonly DormitoryContext _dormitoryContext;
    private readonly ILogger<UpdateDormitoryEndpoint> _logger;
    public UpdateDormitoryEndpoint(DormitoryContext dormitoryContext, ILogger<UpdateDormitoryEndpoint> logger)
    {
        _dormitoryContext = dormitoryContext;
        _logger = logger;
    }
    
    public override async Task HandleAsync(UpdateDormitoryRequest req, CancellationToken ct)
    {
        var entity = await _dormitoryContext.Dormitories.FirstOrDefaultAsync(
            x=>x.Id == req.Id, cancellationToken: ct);
        if( entity is null)
        {
            _logger.LogInformation("Dormitory not found by this Id");
            await SendNotFoundAsync(ct);
        }

        entity.BuldingName = req.BuldingName;
        entity.Address = req.Address;
        entity.PostIndex = req.PostIndex;
        entity.RoomCount = req.RoomCount;
        entity.PersonCount = req.PersonCount;
        entity.FreeBedCount = req.FreeBedCount;
            
        _dormitoryContext.Dormitories.Update(entity);
        await _dormitoryContext.SaveChangesAsync(ct);
        await SendOkAsync(ct);
    }
}
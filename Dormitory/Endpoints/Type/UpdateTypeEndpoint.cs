using Dormitory.Entityes;
using Dormitory.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.Type;

[HttpPut("/type/{{id}}")][AllowAnonymous]
public class UpdateTypeEndpoint:Endpoint<UpdateTypeRequest, UpdateTypeResponse>
{
    private readonly DormitoryContext _typeContext;
    private readonly ILogger<UpdateTypeEndpoint> _logger;
    public UpdateTypeEndpoint(DormitoryContext typeContext, ILogger<UpdateTypeEndpoint> logger)
    {
        _typeContext = typeContext;
        _logger = logger;
    }
    
    public override async Task HandleAsync(UpdateTypeRequest req, CancellationToken ct)
    {
        var entity = await _typeContext.Types.FirstOrDefaultAsync(
            x=>x.Id == req.Id, cancellationToken: ct);
        
        if( entity is null)
        {
            _logger.LogInformation("TypeItem not found by this Id");
            await SendNotFoundAsync(ct);
        }
        
        entity.TypeRoom = req.TypeRoom;
        entity.Price = req.Price;
       
        _typeContext.Types.Update(entity);
        await _typeContext.SaveChangesAsync(ct);
        await SendOkAsync(ct);

    }
}
using Dormitory.Entityes;
using Dormitory.Services;
using Dormitory.Services.Request.Type;
using Dormitory.Services.Response.Type;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.Type;

[HttpDelete("/type/{id}")] [AllowAnonymous]
public class DeleteTypeEndpoint:Endpoint<DeleteTypeRequest, DeleteTypeResponse>
{
    private readonly DormitoryContext _typeContext;
    private readonly ILogger<DeleteTypeEndpoint> _logger;
    public DeleteTypeEndpoint(DormitoryContext typeContext, ILogger<DeleteTypeEndpoint> logger)
    {
        _typeContext = typeContext;
        _logger = logger;
    }
    public override async Task HandleAsync(DeleteTypeRequest req, CancellationToken ct)
    {
        var entity = await _typeContext.Types.FirstOrDefaultAsync(
            x=>x.Id == req.Id, cancellationToken: ct);
        if( entity is null)
        {
            _logger.LogInformation("TypeItem not found by this Id");
            await SendNotFoundAsync(ct);
        }
        
        _typeContext.Types.Remove(entity);
        await _typeContext.SaveChangesAsync(ct);
        await SendOkAsync(ct);
       
    }
    
}
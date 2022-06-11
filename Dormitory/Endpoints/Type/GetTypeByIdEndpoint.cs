using Dormitory.Entityes;
using Dormitory.Mapper;
using Dormitory.Services;
using Dormitory.Services.Request.Type;
using Dormitory.Services.Response.Type;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.Type;


[HttpGet("/type/{id}")][AllowAnonymous]
public class GetTypeByIdEndpoint: Endpoint<GetByIdTypeRequest, GetByIdTypeResponse>
{
    private readonly DormitoryContext _typeContext;
    private readonly ILogger<GetTypeByIdEndpoint> _logger;
    public GetTypeByIdEndpoint(DormitoryContext typeContext, ILogger<GetTypeByIdEndpoint> logger)
    {
        _typeContext = typeContext;
        _logger = logger;
    }
    
    public override async Task HandleAsync(GetByIdTypeRequest req, CancellationToken ct)
    {
        var entity = await _typeContext.Types.FirstOrDefaultAsync(
            x=>x.Id == req.Id, cancellationToken: ct);
        if( entity is null)
        {
            _logger.LogInformation("Type not found by this Id");
            await SendNotFoundAsync(ct);
        }
        
        var response = new GetByIdTypeResponse
        {
            Type =  new TypeViewModel
            {  
                TypeRoom= entity.TypeRoom,
                Price = entity.Price
            }
        };
        await SendAsync(response, cancellation: ct);

    }
}
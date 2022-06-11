using Dormitory.Entityes;
using Dormitory.Mapper;
using Dormitory.Services;
using Dormitory.Services.Request.Type;
using Dormitory.Services.Response.Type;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.Type;

[HttpGet("/type")][AllowAnonymous]
public class GetTypeEndpoint: Endpoint<GetTypeRequest, GetTypeResponse>
{
    private readonly DormitoryContext _typeContext;
    
    public GetTypeEndpoint(DormitoryContext typeContext)
    {
        _typeContext = typeContext;
    }
    public override async Task HandleAsync(GetTypeRequest req, CancellationToken ct)
    {
        var entities = await _typeContext.Types.ToListAsync(ct);
        var response = new GetTypeResponse()
        {
            Type = entities.Select(f => new TypeViewModel()
            {   Id =f.Id,
                TypeRoom = f.TypeRoom,
                Price= f.Price
                
            })
        };
        await SendAsync(response, cancellation: ct);

    }

}
using Dormitory.Entityes;
using Dormitory.Mapper;
using Dormitory.Services;
using Dormitory.Services.Request.Dormitory;
using Dormitory.Services.Response.Dormitory;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.Dormitories;

[HttpGet("/dormitory/{id}")][AllowAnonymous]
public class GetByIdDormitoryEndpoint : Endpoint<GetByIdDormitoryRequest, GetByIdDormitoryResponse>
{ 
    private readonly DormitoryContext _dormitoryContext;
    private readonly ILogger<GetByIdDormitoryEndpoint> _logger;
    
    public GetByIdDormitoryEndpoint(DormitoryContext dormitoryContext, ILogger<GetByIdDormitoryEndpoint> logger)
    {
        _dormitoryContext = dormitoryContext;
        _logger = logger;
    }
    
    
    public override async Task HandleAsync(GetByIdDormitoryRequest req, CancellationToken ct)
    {
        var entity = await _dormitoryContext.Dormitories.FirstOrDefaultAsync(
            x=>x.Id == req.Id, cancellationToken: ct);
        if( entity is null)
        {
            _logger.LogInformation("Dormitory not found by this Id");
            await SendNotFoundAsync(ct);
        }
        
        var response = new GetByIdDormitoryResponse
        {
            Dormitory =  new DormitoryViewModel
            {
                BuldingName = entity.BuldingName,
                Address = entity.Address,
                PostIndex= entity.PostIndex,
                RoomCount= entity.RoomCount,
                PersonCount= entity.PersonCount,
                FreeBedCount= entity.FreeBedCount
            }
        };
        await SendAsync(response, cancellation: ct);

    }
}
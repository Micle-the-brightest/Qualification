using Dormitory.Entityes;
using Dormitory.Mapper;
using Dormitory.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.Dormitories;

[HttpGet("/dormitory")][AllowAnonymous]
public class GetDormitoryEndpoint: Endpoint<GetDormitoryRequest, GetDormitoryResponse>
{
    private readonly DormitoryContext _dormitoryContext;
    
    public GetDormitoryEndpoint(DormitoryContext dormitoryContext)
    {
        _dormitoryContext = dormitoryContext;
        
    }

    public override async Task HandleAsync(GetDormitoryRequest req, CancellationToken ct)
    {
        var entities = await _dormitoryContext.Dormitories.ToListAsync(ct);
        var response = new GetDormitoryResponse
        {
            Dormitories = entities.Select(f => new DormitoryViewModel
            {
                BuldingName = f.BuldingName,
                Address= f.Address,
                PostIndex= f.PostIndex,
                RoomCount= f.RoomCount,
                PersonCount= f.PersonCount,
                FreeBedCount= f.FreeBedCount
            })
        };
        await SendAsync(response, cancellation: ct);

    }
    
}
using Dormitory.Entityes;
using Dormitory.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Dormitory.Endpoints.Dormitories;
[HttpPost("/dormitory")][AllowAnonymous]
public class CreateDormitoryEndpoint : Endpoint<CreateDormitoryRequest, CreateDormitoryResponse>
{
    private readonly DormitoryContext _dormitoryContext;
    
    public CreateDormitoryEndpoint(DormitoryContext dormitoryContext)
    {
        _dormitoryContext = dormitoryContext;
        
    }

    public override async Task HandleAsync(CreateDormitoryRequest req, CancellationToken ct)
    {
        var entity = new Entityes.Dormitory
        {
            Id = req.Id,
            BuldingName = req.BuldingName,
            Address= req.Address,
            PostIndex= req.PostIndex,
            RoomCount= req.RoomCount,
            PersonCount = req.PersonCount,
            FreeBedCount= req.FreeBedCount
        };
       await _dormitoryContext.AddAsync(entity, ct);
       await SendOkAsync(ct);
    }
}
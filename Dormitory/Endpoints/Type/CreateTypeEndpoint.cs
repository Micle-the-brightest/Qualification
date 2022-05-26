using Dormitory.Entityes;
using Dormitory.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Dormitory.Endpoints.Dormitories;


[HttpPost("/type")][AllowAnonymous]
public class CreateTypeEndpoint: Endpoint<CreateTypeRequest,CreateTypeResponse>
{
    private readonly DormitoryContext _typeContext;
    
    public CreateTypeEndpoint(DormitoryContext typeContext)
    {
        _typeContext = typeContext;
    }

    public override async Task HandleAsync(CreateTypeRequest req, CancellationToken ct)
    {
        var entity = new Entityes.Type
        {
            Id = req.Id,
            TypeRoom = req.TypeRoom,
            Price = req.Price
        };
        await _typeContext.AddAsync(entity, ct);
        await SendOkAsync(ct);
    }
}
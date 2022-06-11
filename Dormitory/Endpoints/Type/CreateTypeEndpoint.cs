using Dormitory.Entityes;
using Dormitory.Services.Request.Type;
using Dormitory.Services.Response.Type;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Dormitory.Endpoints.Type;


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
            TypeRoom = req.TypeRoom,
            Price = req.Price
        };
        await _typeContext.AddAsync(entity, ct);
        await _typeContext.SaveChangesAsync(ct); //додати у всі креейти
        await SendOkAsync(ct);
    }
}
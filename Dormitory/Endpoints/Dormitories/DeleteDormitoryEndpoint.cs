using Dormitory.Entityes;
using Dormitory.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.Endpoints.Dormitories;

[HttpDelete("/dormitory/{{id}}")][AllowAnonymous]
public class DeleteDormitoryEndpoint :Endpoint<DeleteDormitoryRequest, DeleteDormitoryResponse>
{
    private readonly DormitoryContext _dormitoryContext;
    private readonly ILogger<DeleteDormitoryEndpoint> _logger;
    public DeleteDormitoryEndpoint(DormitoryContext dormitoryContext, ILogger<DeleteDormitoryEndpoint> logger)
    {
        _dormitoryContext = dormitoryContext;
        _logger = logger;
    }
    public override async Task HandleAsync(DeleteDormitoryRequest req, CancellationToken ct)
    {
        var entity = await _dormitoryContext.Dormitories.FirstOrDefaultAsync(
            x=>x.Id == req.Id, cancellationToken: ct);
        if( entity is null)
        {
            _logger.LogInformation("Dormitory not found by this Id");
            await SendNotFoundAsync(ct);
        }

        _dormitoryContext.Dormitories.Remove(entity);
        await _dormitoryContext.SaveChangesAsync(ct);
        await SendOkAsync(ct);
        

    }
}
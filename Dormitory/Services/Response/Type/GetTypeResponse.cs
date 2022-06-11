using Dormitory.Mapper;

namespace Dormitory.Services.Response.Type;

public class GetTypeResponse
{
    public IEnumerable<TypeViewModel> Type { get; set; }
        = new List<TypeViewModel>();
}
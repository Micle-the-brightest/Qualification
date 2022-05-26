using Dormitory.Mapper;

namespace Dormitory.Services;

public class GetTypeResponse
{
    public IEnumerable<TypeViewModel> Type { get; set; }
        = new List<TypeViewModel>();
}
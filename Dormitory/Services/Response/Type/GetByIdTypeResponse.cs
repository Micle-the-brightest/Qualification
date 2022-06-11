using Dormitory.Mapper;

namespace Dormitory.Services.Response.Type;

public class GetByIdTypeResponse
{
    public TypeViewModel Type { get; set; }
        = new TypeViewModel();
}
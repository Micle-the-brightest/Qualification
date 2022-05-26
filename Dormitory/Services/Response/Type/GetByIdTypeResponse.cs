using Dormitory.Mapper;

namespace Dormitory.Services;

public class GetByIdTypeResponse
{
    public TypeViewModel Type { get; set; }
        = new TypeViewModel();
}
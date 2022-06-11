using Dormitory.Mapper;

namespace Dormitory.Services.Response.Dormitory;

public class GetDormitoryResponse
{
    public IEnumerable<DormitoryViewModel> Dormitories { get; set; }
        = new List<DormitoryViewModel>();

}
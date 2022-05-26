using Dormitory.Mapper;

namespace Dormitory.Services;

public class GetDormitoryResponse
{
    public IEnumerable<DormitoryViewModel> Dormitories { get; set; }
        = new List<DormitoryViewModel>();

}
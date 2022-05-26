using Dormitory.Mapper;

namespace Dormitory.Services.Response.Dormitory;

public class GetByIdDormitoryResponse
{
    public DormitoryViewModel Dormitory { get; set; }  // під великим питанням
        = new DormitoryViewModel();
}
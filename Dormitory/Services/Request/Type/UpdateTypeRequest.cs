namespace Dormitory.Services.Request.Type;

public class UpdateTypeRequest
{
    public int Id { set; get; }
    public string TypeRoom { set; get; }
    public double Price { set; get; }
}
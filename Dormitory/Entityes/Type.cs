namespace Dormitory.Entityes;

    public class Type
    {
        public int Id { set; get; }
        public string TypeRoom { set; get; }
        public double Price { set; get; }
        
        public List<Room> Rooms { set; get; } // багато до 1
    }
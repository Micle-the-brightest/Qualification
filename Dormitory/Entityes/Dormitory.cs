namespace Dormitory.Entityes
{
    public class Dormitory
    {
        public int Id { set; get; }
        public string BuldingName { set; get; }
        public string Address { set; get; }
        public int PostIndex { set; get; }
        public int RoomCount { set; get; }
        public int PersonCount { set; get; }
        public int FreeBedCount { set; get; }    
        
        public List<Room> Rooms { set; get; }    // багато до 1
        
        
    }
}

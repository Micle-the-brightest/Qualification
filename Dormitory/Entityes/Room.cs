namespace Dormitory.Entityes;

    public class Room
    {
        public int Id { set; get; }
       
        public int NumRoom { set; get; }
        public int RoomCount { set; get; }
        public int PersonCount { set; get; }
        public int FreeBedCount { set; get; }
        public double RoomArea { set; get; }
        public string RoomSex { set; get; }
        public int DormitoryId { set; get; }     //1 до багато 
        public int TypeId { set; get; }          //1 до багато 
        public Dormitory Dormitory { set; get; } //1 до багато 
        public Type Type { set; get; }           //1 до багато 
        
        public List<RoomInfo> RoomInfos { set; get; }    // багато до 1

    }
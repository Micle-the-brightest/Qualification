using Microsoft.EntityFrameworkCore;

namespace Dormitory.Entityes
{
    public class DormitoryContext: DbContext 
    {
        public DormitoryContext(DbContextOptions<DormitoryContext> options)
            : base(options)
        {
        }
        
        public DbSet<Dormitory> Dormitories { get; set; }
        
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomInfo> RoomsInfo { get; set; }
        public DbSet<Type> Types { get; set; }

        
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DormitoryContext).Assembly);
        }
    }
}

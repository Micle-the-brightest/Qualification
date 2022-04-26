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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DormitoryContext).Assembly);
        }
    }
}

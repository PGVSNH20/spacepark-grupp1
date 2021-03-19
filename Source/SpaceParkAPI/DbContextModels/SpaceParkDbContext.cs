using Microsoft.EntityFrameworkCore;

namespace SpaceParkAPI.DbContextModels
{
    public class SpaceParkDbContext : DbContext
    {
        public DbSet<ParkingRegistration> ParkingRegistrations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SpaceParkDb_edgar;User Id=sa;Password=Password123;");
        }
    }
}
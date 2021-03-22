using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SpaceParkAPI.DbContextModels
{
    public class SpaceParkDbContext : DbContext
    {
        public SpaceParkDbContext()
        {
        }

        public SpaceParkDbContext(DbContextOptions<SpaceParkDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(t => t.StarshispUrl);
            modelBuilder.Entity<User>().Ignore(t => t.StarshipsId);
            modelBuilder.Entity<User>().Ignore(t => t.HomePlanetUrl);
            modelBuilder.Entity<User>().Ignore(t => t.HomePlanetId);
            modelBuilder.Entity<User>().Ignore(t => t.SWPeopleUrl);
            modelBuilder.Entity<User>().Ignore(t => t.SWPeopleId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ParkingRegistration> ParkingRegistrations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SpaceParkDb_edgar;User Id=sa;Password=My!P@ssw0rd1;");
        }
    }

    public class SpaceParkContextFactory : IDesignTimeDbContextFactory<SpaceParkDbContext>
    {
        public SpaceParkDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SpaceParkDbContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SpaceParkDb_edgar;User Id=sa;Password=My!P@ssw0rd1;");

            return new SpaceParkDbContext(optionsBuilder.Options);
        }
    }
}
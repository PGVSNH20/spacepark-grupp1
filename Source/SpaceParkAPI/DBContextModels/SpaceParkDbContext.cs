using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.DBContextModels
{
    internal class SpaceParkDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<ParkingRegistration> ParkingRegistrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SpaceParkDb_edgar;User Id=sa;Password=Password123;");
        }
    }
}

docker run -d -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password123" -p 1433:1433--name SpaceParkDb mcr.microsoft.com/mssql/server:2019 - latest
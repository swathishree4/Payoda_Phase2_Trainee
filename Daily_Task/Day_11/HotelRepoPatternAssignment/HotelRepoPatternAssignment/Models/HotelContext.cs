using Microsoft.EntityFrameworkCore;
using System.Data.Common;


namespace HotelRepoPatternAssignment.Models
{
    public class HotelContext:DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=PTSQLTESTDB01;database=Hotel_Swathi;integrated security=true;trustservercertificate =true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel() { HotelId = 1, HotelName = "Orbits Hotel" },
                new Hotel() { HotelId = 2, HotelName = "Taj Hotel" });

            modelBuilder.Entity<Room>()
                .HasData(new Room() { RoomNo = 101, RoomType = "AC Room", Price = 50000, HotelId = 2 },
                new Room { RoomNo = 102, RoomType = "Non-AC Room", Price = 25000, HotelId = 1 });

            modelBuilder.Entity<Hotel>()
                .HasMany(r => r.Rooms)
                .WithOne(h => h.Hotel)
                .HasForeignKey(c => c.HotelId);

            modelBuilder.Entity<Room>()
                .Property(p => p.Price)
                .HasColumnType("decimal(10,2)");
        }
    }
}

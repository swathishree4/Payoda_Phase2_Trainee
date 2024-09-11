using Microsoft.EntityFrameworkCore;
using Apiproject.Model;
using API_MINI_MAIN.Model;

namespace Apiproject.Model
{
    public class AppDbContext : DbContext
    {

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }

        public DbSet<User> users { set; get; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Games)
                .WithOne(g => g.Player)
                .HasForeignKey(g => g.PlayerId);
        }
       

    }
}

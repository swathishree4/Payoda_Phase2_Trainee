using Microsoft.EntityFrameworkCore;

namespace MVC_MAINTEST.Models
{
    public class ApplicationDbContext:DbContext
    {
       
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

    }
}

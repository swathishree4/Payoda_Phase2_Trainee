using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.Model
{
    public class BookDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }  
        public DbSet<User> users { get; set; }
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }
    }
}

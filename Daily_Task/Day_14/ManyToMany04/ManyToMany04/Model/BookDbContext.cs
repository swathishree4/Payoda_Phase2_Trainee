using Microsoft.EntityFrameworkCore;
using ManyToMany04.Model;

namespace ManyToMany04.Model
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.book)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(a => a.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(a => a.AuthorId);
        }
        public DbSet<ManyToMany04.Model.Author> Author { get; set; } = default!;
        public DbSet<ManyToMany04.Model.Book> Book { get; set; } = default!;
        public DbSet<ManyToMany04.Model.BookAuthor> BookAuthor { get; set; } = default!;
    }
}

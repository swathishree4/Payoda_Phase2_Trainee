using ManyToMany04.Interface;
using ManyToMany04.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ManyToMany04.Repository
{
    public class BookRepository:IBook
    {
        private readonly BookDbContext _context;
        public BookRepository(BookDbContext context)
        {
            _context = context;
        }
       // GET: api/Books
        //[HttpGet]
        public async Task<IEnumerable<Book>> GetBook()
        {
            return await _context.Book.Include(b => b.BookAuthors!)
                  .ThenInclude(a => a.author)
                  .ToListAsync();
        }

        // GET: api/Books/5
        //[HttpGet("{id}")]
        public async Task<Book> GetBookById(int id)
        {
              return await _context.Book.Include(b => b.BookAuthors!)
                  .ThenInclude(a => a.author).FirstOrDefaultAsync(e => e.BookId == id)??throw new NullReferenceException();
        }

        // PUT: api/Books/5
       
        //[HttpPut("{id}")]
        public async Task PutBook(int id, Book e)
        {
            if (id == e.BookId)
            {
                _context.Entry(e).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        // POST: api/Books
      
        [HttpPost]
        public async Task PostBook(Book e)
        {
            await _context.Book.AddAsync(e);
            await _context.SaveChangesAsync();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task DeleteBook(int id)
        {
            var b= await _context.Book.FindAsync(id);
            if (b != null)
            {
                _context.Book.Remove(b);
                await _context.SaveChangesAsync();
            }
        }
    }
}

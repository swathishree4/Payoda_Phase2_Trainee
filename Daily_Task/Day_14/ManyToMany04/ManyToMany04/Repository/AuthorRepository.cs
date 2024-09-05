using ManyToMany04.Interface;
using ManyToMany04.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany04.Repository
{
    public class AuthorRepository:IAuthor
    {
        private readonly BookDbContext _context;
        public AuthorRepository(BookDbContext context)
        {
            _context = context;
        }
        // GET: api/Books
        //[HttpGet]
        public async Task<IEnumerable<Author>> GetAuthor()
        {
            return await _context.Author.Include(b => b.BookAuthors!)
                  .ThenInclude(a => a.book)
                  .ToListAsync();
        }

        // GET: api/Books/5
        //[HttpGet("{id}")]
        public async Task<Author> GetAuthorById(int id)
        {
            return await _context.Author.Include(b => b.BookAuthors!)
                  .ThenInclude(a => a.book).FirstOrDefaultAsync(e => e.AuthorId == id) ?? throw new NullReferenceException();
        }

        // PUT: api/Books/5

        //[HttpPut("{id}")]
        public async Task EditAuthor(int id, Author e)
        {
            if (id == e.AuthorId)
            {
                _context.Entry(e).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        // POST: api/Books

        [HttpPost]
        public async Task AddAuthor(Author e)
        {
            await _context.Author.AddAsync(e);
            await _context.SaveChangesAsync();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task DeleteAuthor(int id)
        {
            var b = await _context.Author.FindAsync(id);
            if (b != null)
            {
                _context.Author.Remove(b);
                await _context.SaveChangesAsync();
            }
        }
    }
}

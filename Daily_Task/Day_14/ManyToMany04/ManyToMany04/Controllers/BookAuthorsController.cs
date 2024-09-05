
using ManyToMany04.Model;
using ManyToMany04.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIAuthorBooksApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController : ControllerBase
    {
        private readonly AuthorService _author;
        private readonly BookService _book;
        public BookAuthorController(AuthorService author, BookService book)
        {
            _author = author;
            _book = book;
        }

        // GET: api/<BookAuthorController>
        //[HttpGet]
        //public async Task<IEnumerable<BookAuthor>?> Get()
        //{
        //    return null;
        //}

        // GET: api/<BookAuthorController>/Auhtor/5
        [HttpGet("Author/{authorId}")]
        public async Task<IActionResult> GetBookAuthorByAuthorId(int authorId)
        {
            var author = await _author.Getakbyid(authorId);

            if (author == null) return NotFound();

            var books = author.BookAuthors;
            return Ok(books);
        }

        // GET: api/<BookAuthorController>/Book/5
        [HttpGet("Book/{bookId}")]
        public async Task<IActionResult> GetBookAuthorByBookId(int bookId)
        {
            var book = await _book.Getbkbyid(bookId);

            if (book == null) return NotFound();

            var authors = book.BookAuthors;
            return Ok(authors);
        }

        // POST api/<BookAuthorController>
        [HttpPost]
        public async Task<IActionResult> EnrollStudentInCourse([FromBody] BookAuthor bookAuthor)
        {
            if (bookAuthor == null)
            {
                return BadRequest("BookAuthor cannot be null");
            }

            // Fetch the author and book to verify they exist
            var author = await _author.Getakbyid(bookAuthor.AuthorId);
            var book = await _book.Getbkbyid(bookAuthor.BookId);

            if (author == null || book == null)
            {
                return NotFound("Author or Book not found");
            }

            // Check if the author is already enrolled in the books
            var existingEnrollment = author.BookAuthors?
                                            .FirstOrDefault(sc => sc.BookId == bookAuthor.BookId);
            if (existingEnrollment != null)
            {
                return Conflict("Author is already added in this book");
            }

            // Add the student-course relationship
            author.BookAuthors?.Add(bookAuthor);
            book.BookAuthors?.Add(bookAuthor);

            // Update both the student and course entities in the database
            await _author.Updateak(author.AuthorId, author);
            await _book.Updatebk(book.BookId, book);

            return CreatedAtAction(nameof(GetBookAuthorByAuthorId), new { studentId = bookAuthor.AuthorId }, bookAuthor);
        }

        // DELETE api/<BookAuthorController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(BookAuthor bookAuthor)
        {
            if (bookAuthor == null) return BadRequest("BookAuhtor can not be null");

            var author = await _author.Getakbyid(bookAuthor.AuthorId);
            var book = await _book.Getbkbyid(bookAuthor.BookId);

            if (author == null || book == null) return BadRequest("Author or Book not found");

            author.BookAuthors!.Remove(bookAuthor);
            book.BookAuthors!.Remove(bookAuthor);

            await _author.Updateak(author.AuthorId, author);
            await _book.Updatebk(book.BookId, book);

            return Ok("BookAuthor Deleted.");
        }
    }
}
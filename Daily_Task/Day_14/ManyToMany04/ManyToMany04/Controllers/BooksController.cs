using ManyToMany04.Model;
using ManyToMany04.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManyToMany04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bkser;
        public BooksController(BookService bkser)
        {
            _bkser = bkser;
        }
        // GET: api/<BookController>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bkser.Getbk();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await _bkser.Getbkbyid(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book emp)
        {
            await _bkser.Addbk(emp);
            return Ok("Employee added successfully");
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book e)
        {
            await _bkser.Updatebk(id, e);

            return Ok("Employee Updated successfully");
        }


        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bkser.Deletebk(id);
            return Ok("Company Deleted successfully");
        }
    }
}

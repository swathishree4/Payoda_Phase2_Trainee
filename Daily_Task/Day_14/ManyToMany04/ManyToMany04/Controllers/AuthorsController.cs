using ManyToMany04.Model;
using ManyToMany04.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManyToMany04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _akser;
        public AuthorsController(AuthorService akser)
        {
            _akser = akser;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<IEnumerable<Author>> GetAuthor()
        {
            return await _akser.Getak();
        }


        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<Author>  GetAuthorById(int id)
        {
            return await _akser.Getakbyid(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] Author emp)
        {
            await _akser.Addak(emp);
            return Ok("Employee added successfully");
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAuthor(int id, [FromBody] Author e)
        {
            await _akser.Updateak(id, e);

            return Ok("Employee Updated successfully");
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _akser.Deleteak(id);
            return Ok("Company Deleted successfully");
        }
    }
}

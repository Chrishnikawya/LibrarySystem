using LibrarySystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        

        // GET: api/<AuthorController1>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _authorService.GetAuthors();
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _authorService.PostAuthors();
            return ;
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _authorService.PutAuthors();
            return;
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _authorService.DeleteAuthors();
            return;
        }
    }
}

using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;


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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Get()
        {
            var authors = await _authorService.GetAuthorAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            var authors = await _authorService.GetAuthorAsync();
            var author = authors.FirstOrDefault(a => a.AuthorID == id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            var inserted = await _authorService.AddAuthorAsync(author);
            if (inserted)
            {
                return CreatedAtAction(nameof(Get), new { id = author.AuthorID }, author);
            }
            return BadRequest("Failed to add author.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Author author)
        {
            if (author == null || id != author.AuthorID)
            {
                return BadRequest();
            }

            var updated = await _authorService.EditAuthorAsync(author);
            if (updated)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removed = await _authorService.RemoveAuthorAsync(id);
            if (removed)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;


namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var books = await _bookService.GetBookAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var books = await _bookService.GetBookAsync();
            var book = books.FirstOrDefault(b => b.BookID == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var inserted = await _bookService.AddBookAsync(book);
            if (inserted)
            {
                return CreatedAtAction(nameof(Get), new { id = book.BookID }, book);
            }
            return BadRequest("Failed to add book.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Book book)
        {
            if (book == null || id != book.BookID)
            {
                return BadRequest();
            }

            var updated = await _bookService.EditBookAsync(book);
            if (updated)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removed = await _bookService.RemoveBookAsync(id);
            if (removed)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

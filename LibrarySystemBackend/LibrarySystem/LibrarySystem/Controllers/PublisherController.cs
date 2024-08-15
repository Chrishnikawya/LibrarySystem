using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: api/Publisher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> Get()
        {
            var publishers = await _publisherService.GetPublisherAsync();
            return Ok(publishers);
        }

        // GET api/Publisher/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> Get(int id)
        {
            var publishers = await _publisherService.GetPublisherAsync();
            var publisher = publishers.FirstOrDefault(p => p.PublisherID == id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }

        // POST api/Publisher
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Publisher publisher)
        {
            if (publisher == null)
            {
                return BadRequest();
            }
            var inserted = await _publisherService.AddPublisherAsync(publisher);
            if (inserted)
            {
                return CreatedAtAction(nameof(Get), new { id = publisher.PublisherID }, publisher);
            }
            return BadRequest("Failed to add publisher.");
        }

        // PUT api/Publisher/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Publisher publisher)
        {
            if (publisher == null || id != publisher.PublisherID)
            {
                return BadRequest();
            }

            var updated = await _publisherService.EditPublisherAsync(publisher);
            if (updated)
            {
                return NoContent();
            }
            return NotFound();
        }

        // DELETE api/Publisher/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removed = await _publisherService.RemovePublisherAsync(id);
            if (removed)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

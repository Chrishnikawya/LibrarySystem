using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;


namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResevationController : ControllerBase
    {
        private readonly IResevationService _resevationService;

        public ResevationController(IResevationService resevationService)
        {
            _resevationService = resevationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resevation>>> Get()
        {
            var resevations = await _resevationService.GetResevationAsync();
            return Ok(resevations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resevation>> Get(int id)
        {
            var resevations = await _resevationService.GetResevationAsync();
            var resevation = resevations.FirstOrDefault(r => r.ReservationID == id);
            if (resevation == null)
            {
                return NotFound();
            }
            return Ok(resevation);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Resevation resevation)
        {
            if (resevation == null)
            {
                return BadRequest();
            }
            var inserted = await _resevationService.AddResevationAsync(resevation);
            if (inserted)
            {
                return CreatedAtAction(nameof(Get), new { id = resevation.ReservationID }, resevation);
            }
            return BadRequest("Failed to add reservation.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Resevation resevation)
        {
            if (resevation == null || id != resevation.ReservationID)
            {
                return BadRequest();
            }

            var updated = await _resevationService.EditResevationAsync(resevation);
            if (updated)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removed = await _resevationService.RemoveResevationAsync(id);
            if (removed)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

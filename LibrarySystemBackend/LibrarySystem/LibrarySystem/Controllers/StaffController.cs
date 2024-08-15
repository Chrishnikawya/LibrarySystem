using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;


namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> Get()
        {
            var staff = await _staffService.GetStaffAsync();
            return Ok(staff);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> Get(int id)
        {
            var staff = await _staffService.GetStaffAsync();
            var member = staff.FirstOrDefault(s => s.StaffID == id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Staff staff)
        {
            if (staff == null)
            {
                return BadRequest();
            }
            var inserted = await _staffService.AddStaffAsync(staff);
            if (inserted)
            {
                return CreatedAtAction(nameof(Get), new { id = staff.StaffID }, staff);
            }
            return BadRequest("Failed to add staff.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Staff staff)
        {
            if (staff == null || id != staff.StaffID)
            {
                return BadRequest();
            }

            var updated = await _staffService.EditStaffAsync(staff);
            if (updated)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removed = await _staffService.RemoveStaffAsync(id);
            if (removed)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

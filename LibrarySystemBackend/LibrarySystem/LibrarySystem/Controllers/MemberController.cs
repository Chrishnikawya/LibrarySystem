using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;


namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        // GET: api/Member
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> Get()
        {
            var members = await _memberService.GetMemberAsync();
            return Ok(members);
        }

        // GET api/Member/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> Get(int id)
        {
            var members = await _memberService.GetMemberAsync();
            var member = members.FirstOrDefault(m => m.MemberID == id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        // POST api/Member
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Member member)
        {
            if (member == null)
            {
                return BadRequest();
            }
            var inserted = await _memberService.AddMemberAsync(member);
            if (inserted)
            {
                return CreatedAtAction(nameof(Get), new { id = member.MemberID }, member);
            }
            return BadRequest("Failed to add member.");
        }

        // PUT api/Member/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Member member)
        {
            if (member == null || id != member.MemberID)
            {
                return BadRequest();
            }

            var updated = await _memberService.EditMemberAsync(member);
            if (updated)
            {
                return NoContent();
            }
            return NotFound();
        }

        // DELETE api/Member/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removed = await _memberService.RemoveMemberAsync(id);
            if (removed)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

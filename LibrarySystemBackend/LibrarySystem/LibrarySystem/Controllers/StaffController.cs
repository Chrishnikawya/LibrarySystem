using LibrarySystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<StaffController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _staffService.GetStaffAsync();
            return new string[] { "value1", "value2" };
        }

        // GET api/<StaffController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StaffController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _staffService.AddStaffAsync();
            return;
        }

        // PUT api/<StaffController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _staffService.EditStaffAsync();
            return;
        }

        // DELETE api/<StaffController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _staffService.RemoveStaffAsync();
            return;
        }
    }
}

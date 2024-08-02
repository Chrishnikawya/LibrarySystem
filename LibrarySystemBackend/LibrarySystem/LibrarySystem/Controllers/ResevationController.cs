using LibrarySystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<ResevationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _resevationService.GetResevationAsync();
            return new string[] { "value1", "value2" };
        }

        // GET api/<ResevationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ResevationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _resevationService.AddResevationAsync();
            return;
        }

        // PUT api/<ResevationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _resevationService.EditResevationAsync();
            return;
        }

        // DELETE api/<ResevationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _resevationService.RemoveResevationAsync();
            return;
        }
    }
}

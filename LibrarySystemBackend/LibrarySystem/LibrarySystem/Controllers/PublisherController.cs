using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;

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

        [HttpGet]
        [ProducesResponseType(typeof(List<PublisherViewModel>), StatusCodes.Status200OK)]
        public async Task<List<PublisherViewModel>> GetPublisher()
        {
            try
            {
                var publishers= await _publisherService.GetPublisherAsync();
                return publishers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> Get(int id)
        {
            try
            {
                var publishers = await _publisherService.GetPublisherAsync();
                var publisher = publishers.FirstOrDefault(a => a.PublisherID == id);
                if (publisher == null)
                {
                    return NotFound();
                }
                return Ok(publisher);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> AddPublisher([FromBody] PublisherViewModel publisherViewModel)
        {
            try
            {
                var insertRes = await _publisherService.AddPublisherAsync(publisherViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = insertRes,
                    Message = insertRes ? Message.PUBLISHER_ADD_SUCCESSFUL : Message.PUBLISHER_ADD_UNSUCCESSFUL
                };
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> EditPublisher([FromBody] PublisherViewModel publisherViewModel)
        {
            try
            {
                var editRes = await _publisherService.EditPublisherAsync(publisherViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = editRes,
                    Message = editRes ? Message.PUBLISHER_EDIT_SUCCESSFUL : Message.PUBLISHER_EDIT_UNSUCCESSFUL
                };
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> DeletePublisher(int publisherId)
        {
            try
            {
                var deleteRes = await _publisherService.RemovePublisherAsync(publisherId);

                var response = new CommonResponse
                {
                    IsSuccess = deleteRes,
                    Message = deleteRes ? Message.PUBLISHER_DELETE_SUCCESSFUL : Message.PUBLISHER_DELETE_UNSUCCESSFUL
                };
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

//using LibrarySystem.Interfaces;
//using LibrarySystem.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace LibrarySystem.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PublisherController : ControllerBase
//    {
//        private readonly IPublisherService _publisherService;

//        public PublisherController(IPublisherService publisherService)
//        {
//            _publisherService = publisherService;
//        }

//        // GET: api/Publisher
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Publisher>>> Get()
//        {
//            var publishers = await _publisherService.GetPublisherAsync();
//            return Ok(publishers);
//        }

//        // GET api/Publisher/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Publisher>> Get(int id)
//        {
//            var publishers = await _publisherService.GetPublisherAsync();
//            var publisher = publishers.FirstOrDefault(p => p.PublisherID == id);
//            if (publisher == null)
//            {
//                return NotFound();
//            }
//            return Ok(publisher);
//        }

//        // POST api/Publisher
//        [HttpPost]
//        public async Task<ActionResult> Post([FromBody] Publisher publisher)
//        {
//            if (publisher == null)
//            {
//                return BadRequest();
//            }
//            var inserted = await _publisherService.AddPublisherAsync(publisher);
//            if (inserted)
//            {
//                return CreatedAtAction(nameof(Get), new { id = publisher.PublisherID }, publisher);
//            }
//            return BadRequest("Failed to add publisher.");
//        }

//        // PUT api/Publisher/5
//        [HttpPut("{id}")]
//        public async Task<ActionResult> Put(int id, [FromBody] Publisher publisher)
//        {
//            if (publisher == null || id != publisher.PublisherID)
//            {
//                return BadRequest();
//            }

//            var updated = await _publisherService.EditPublisherAsync(publisher);
//            if (updated)
//            {
//                return NoContent();
//            }
//            return NotFound();
//        }

//        // DELETE api/Publisher/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult> Delete(int id)
//        {
//            var removed = await _publisherService.RemovePublisherAsync(id);
//            if (removed)
//            {
//                return NoContent();
//            }
//            return NotFound();
//        }
//    }
//}

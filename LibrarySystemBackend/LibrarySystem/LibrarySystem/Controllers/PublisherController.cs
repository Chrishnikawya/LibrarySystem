using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;
using LibrarySystem.Services;

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


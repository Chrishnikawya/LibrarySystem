using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;
using Microsoft.AspNetCore.Authorization;

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
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<ResevationViewModel>), StatusCodes.Status200OK)]
        public async Task<List<ResevationViewModel>> GetResevations()
        {
            try
            {
                var resevations = await _resevationService.GetResevationAsync();
                return resevations.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> AddResevation( ResevationViewModel resevationViewModel)
        {
            try
            {
                var insertRes = await _resevationService.AddResevationAsync(resevationViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = insertRes,
                    Message = insertRes ? Message.RESEVATION_ADD_SUCCESSFUL : Message.RESEVATION_ADD_UNSUCCESSFUL
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
        public async Task<CommonResponse> EditResevation([FromBody] ResevationViewModel resevationViewModel)
        {
            try
            {
                var editRes = await _resevationService.EditResevationAsync(resevationViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = editRes,
                    Message = editRes ? Message.RESEVATION_EDIT_SUCCESSFUL : Message.RESEVATION_EDIT_UNSUCCESSFUL
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
        public async Task<CommonResponse> DeleteResevation(int resevationId)
        {
            try
            {
                var deleteRes = await _resevationService.RemoveResevationAsync(resevationId);

                var response = new CommonResponse
                {
                    IsSuccess = deleteRes,
                    Message = deleteRes ? Message.RESEVATION_DELETE_SUCCESSFUL : Message.RESEVATION_DELETE_UNSUCCESSFUL
                };
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}



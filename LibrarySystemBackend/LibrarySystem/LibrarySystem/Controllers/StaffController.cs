using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;

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
        [ProducesResponseType(typeof(List<StaffViewModel>), StatusCodes.Status200OK)]
        public async Task<List<StaffViewModel>> GetStaffs()
        {
            try
            {
                var staffs = await _staffService.GetStaffAsync();
                return staffs.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> AddStaff([FromBody] StaffViewModel staffViewModel)
        {
            try
            {
                var insertRes = await _staffService.AddStaffAsync(staffViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = insertRes,
                    Message = insertRes ? Message.STAFF_ADD_SUCCESSFUL : Message.STAFF_ADD_UNSUCCESSFUL
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
        public async Task<CommonResponse> EditStaff([FromBody] StaffViewModel staffViewModel)
        {
            try
            {
                var editRes = await _staffService.EditStaffAsync(staffViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = editRes,
                    Message = editRes ? Message.STAFF_EDIT_SUCCESSFUL : Message.STAFF_EDIT_UNSUCCESSFUL
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
        public async Task<CommonResponse> DeleteStaff(int staffId)
        {
            try
            {
                var deleteRes = await _staffService.RemoveStaffAsync(staffId);

                var response = new CommonResponse
                {
                    IsSuccess = deleteRes,
                    Message = deleteRes ? Message.STAFF_DELETE_SUCCESSFUL : Message.STAFF_DELETE_UNSUCCESSFUL
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

﻿using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;
using LibrarySystem.Services;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<MemberViewModel>), StatusCodes.Status200OK)]
        public async Task<List<MemberViewModel>> GetMembers()
        {
            try
            {
                var members = await _memberService.GetMemberAsync();
                return members.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> AddMember([FromBody] MemberViewModel memberViewModel)
        {
            try
            {
                var insertRes = await _memberService.AddMemberAsync(memberViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = insertRes,
                    Message = insertRes ? Message.MEMBER_ADD_SUCCESSFUL : Message.MEMBER_ADD_UNSUCCESSFUL
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
        public async Task<CommonResponse> EditMember([FromBody] MemberViewModel memberViewModel)
        {
            try
            {
                var editRes = await _memberService.EditMemberAsync(memberViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = editRes,
                    Message = editRes ? Message.MEMBER_EDIT_SUCCESSFUL : Message.MEMBER_EDIT_UNSUCCESSFUL
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
        public async Task<CommonResponse> DeleteMember(int memberId)
        {
            try
            {
                var deleteRes = await _memberService.RemoveMemberAsync(memberId);

                var response = new CommonResponse
                {
                    IsSuccess = deleteRes,
                    Message = deleteRes ? Message.MEMBER_DELETE_SUCCESSFUL : Message.MEMBER_DELETE_UNSUCCESSFUL
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

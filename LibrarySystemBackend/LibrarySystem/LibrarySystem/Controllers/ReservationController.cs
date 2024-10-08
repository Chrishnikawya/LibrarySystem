﻿using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using LibrarySystem.Services;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IResevationService _resevationService;

        public ReservationController(IResevationService resevationService)
        {
            _resevationService = resevationService;
        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [AllowAnonymous]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> EditResevation(ResevationViewModel resevationViewModel)
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

        [HttpDelete("{resevationId}")]
        [AllowAnonymous]
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [HttpGet("details")]
        public async Task<IActionResult> GetReservationDetails()
        {
            try
            {
                var details = await _resevationService.GetReservationDetailsAsync();
                return Ok(details);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        [HttpGet("reservationDetails")]
        public async Task<IActionResult> GetReservationDetailsView()
        {
            try
            {
                var reservationDetails = await _resevationService.GetReservationDetailsViewAsync();
                return Ok(reservationDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}



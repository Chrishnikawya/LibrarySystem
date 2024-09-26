
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using LibrarySystem.Interfaces;
using LibrarySystem.Services;
using LibrarySystem.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection.Metadata;
namespace LibrarySystem.Controllers 
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
   
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public UserController(
           IUserService userService,
           IConfiguration configuration,
           IUnitOfWorkRepository unitOfWork)
        {
           _userService = userService;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
                
        }

        //[HttpGet]
        //[AllowAnonymous]
        //[ProducesResponseType(typeof(List<UserViewModel>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetUsers()
        //{
        //    try
        //    {
        //        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //        var user = await _userService.GetUserAsync(userId);
        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        public async Task<UserViewModel> GetUser()
        {
            try
            {
                return await _userService.GetUserAsync(User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpGet]
        //[AllowAnonymous]
        //[ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        //public async Task<UserViewModel> GetUser()
        //{
        //    try
        //    {
        //        // Replace 'User' with the user ID extracted from the claims
        //        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //        if (string.IsNullOrEmpty(userId))
        //        {
        //            throw new Exception("User ID not found.");
        //        }

        //        // Now pass the userId instead of the User object
        //        return await _userService.GetUserAsync(userId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}

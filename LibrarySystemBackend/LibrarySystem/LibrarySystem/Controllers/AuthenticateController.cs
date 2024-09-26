
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using LibrarySystem.Interfaces;
using LibrarySystem.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;




namespace LibrarySystem.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public AuthenticateController(
            IAuthenticateService authenticateService,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IUserService userService)
        {
            _authenticateService = authenticateService;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                var result = await _authenticateService.LoginAsync(model);
                if(result.IsSuccess) 
                {
                    return Ok(result);
                }
                

                else { 
                  return Unauthorized();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<CommonResponse> Register(RegisterViewModel model)

        {

            try
            {
                var registerRes = await _authenticateService.RegisterAsync(model);

                var response = new CommonResponse
                {
                    IsSuccess = true,
                    Message = registerRes != null ? Message.REGISTER_SUCCESSFUL : Message.REGISTER_UNSUCCESSFUL
                };
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<CommonResponse> RegisterAdmin([FromBody] RegisterViewModel model)
        {
            try
            {
                var registerRes = await _authenticateService.RegisterAdminAsync(model);

                var response = new CommonResponse
                {
                    IsSuccess = true,
                    Message = registerRes != null ? Message.REGISTER_ADMIN_SUCCESSFUL : Message.REGISTER_ADMIN_UNSUCCESSFUL
                };
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

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
        //[HttpGet]
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

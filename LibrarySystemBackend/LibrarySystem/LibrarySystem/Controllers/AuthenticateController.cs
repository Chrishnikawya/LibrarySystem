
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using LibrarySystem.Interfaces;
using LibrarySystem.Repositories;
using LibrarySystem.Services;




namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(
            IAuthenticateService authenticateService,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _authenticateService = authenticateService;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
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

     
    }
}

using LibrarySystem.Constant;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using LibrarySystem.Response;
using LibrarySystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibrarySystem.Services
{
    public class AuthenticateService:IAuthenticateService
    {
        private readonly UserManager<IdentityUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly IConfiguration _configuration;

            public AuthenticateService(
                UserManager<IdentityUser> userManager,
                RoleManager<IdentityRole> roleManager,
                IConfiguration configuration)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _configuration = configuration;
            }
        /// <summary>
        /// Authenticate service
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
            public async Task<LoginResponse> LoginAsync(LoginViewModel model)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(model.Username);
                    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);

                        var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                        foreach (var userRole in userRoles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                        }

                        var token = GetToken(authClaims);

                        return new LoginResponse
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            Expiration = token.ValidTo,
                            IsSuccess = true,
                            Message = Message.LOGIN_SUCCESSFUL
                        };
                    }
                else
                {
                    return new LoginResponse
                {
                    IsSuccess = false,
                    Message = Message.LOGIN_UNSUCCESSFUL
                };
                }
            }
                catch (Exception ex)
                {

                    throw ex;
                }  
             
            }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
            public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)

            {
                try
                {
                    var userExists = await _userManager.FindByNameAsync(model.Username);
                    IdentityUser user = new()
                    {
                        Email = model.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = model.Username
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        /// <summary>
        /// Register Method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
            public async Task<IdentityResult> RegisterAdminAsync(RegisterViewModel model)
            {
            try
            {
                var userExists = await _userManager.FindByNameAsync(model.Username);
                IdentityUser user = new()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                }
                if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.User);
                }
                
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Register Admin Method
        /// </summary>
        /// <param name="authClaims"></param>
        /// <returns></returns>

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return token;
        }
       
           
    }
}


using LibrarySystem.Constant;
using LibrarySystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LibrarySystem.Interfaces
{
    public interface IAuthenticateService
    {
        Task<LoginResponse> LoginAsync(LoginViewModel model);
        Task<IdentityResult> RegisterAsync(RegisterViewModel model);
        Task<IdentityResult> RegisterAdminAsync(RegisterViewModel model);
    }
}

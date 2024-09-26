using LibrarySystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibrarySystem.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserAsync(ClaimsPrincipal User);
    }
}

   

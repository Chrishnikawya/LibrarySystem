using LibrarySystem.Repositories;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Services
{
    public class UserService:IUserService
    {    
        private readonly IUnitOfWorkRepository _unitOfWork;
        public UserService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<UserViewModel> GetUserAsync(string id)
        //{
        //    try
        //    {

        //        var user = await _unitOfWork.Repository<User>()
        //        .FindAsync(u => u.Id == id);
        //        return new UserViewModel
        //        {
        //            UserName = user.UserName,

        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<UserViewModel> GetUserAsync(ClaimsPrincipal principal)
        {
            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _unitOfWork.Repository<User>()
                             .Query()
                             .Where(u => u.Id == userId)
                             .ToListAsync();

            return user.Select(u => new UserViewModel
            {
                UserName = u.UserName
            }).First();
        }
    }
}

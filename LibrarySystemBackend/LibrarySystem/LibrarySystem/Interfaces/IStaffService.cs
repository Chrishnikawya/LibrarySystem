using LibrarySystem.Models;
using LibrarySystem.ViewModels;
namespace LibrarySystem.Interfaces
{
    public interface IStaffService
    {
        Task<bool> AddStaffAsync(StaffViewModel staffViewModel);
        Task<IList<StaffViewModel>> GetStaffAsync();
        Task<bool> EditStaffAsync(StaffViewModel staffViewModel);
        Task<bool> RemoveStaffAsync(int staffId);
    }
}

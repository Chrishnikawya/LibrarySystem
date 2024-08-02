using LibrarySystem.Models;

namespace LibrarySystem.Interfaces
{
    public interface IStaffService
    {
        Task<bool> AddStaffAsync(Staff staff);
        Task<IList<Staff>> GetStaffAsync();
        Task<bool> EditStaffAsync(Staff staff);
        Task<bool> RemoveStaffAsync(int staffId);
    }
}

using LibrarySystem.Models;
using LibrarySystem.ViewModels;
namespace LibrarySystem.Interfaces
{
   
    public interface IMemberService
    {
        Task<bool> AddMemberAsync(MemberViewModel memberViewModel);
        Task<IList<MemberViewModel>> GetMemberAsync();
        Task<bool> EditMemberAsync(MemberViewModel memberViewModel);
        Task<bool> RemoveMemberAsync(int memberId);
    }
}

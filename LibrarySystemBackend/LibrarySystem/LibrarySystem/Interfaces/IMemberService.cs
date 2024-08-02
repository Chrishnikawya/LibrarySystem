using LibrarySystem.Models;

namespace LibrarySystem.Interfaces
{
   
    public interface IMemberService
    {
        Task<bool> AddMemberAsync(Member member);
        Task<IList<Member>> GetMemberAsync();
        Task<bool> EditMemberAsync(Member member);
        Task<bool> RemoveMemberAsync(int memberId);
    }
}

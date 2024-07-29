using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class MemberService:IMemberService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public MemberService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddMemberAsync(Member member)
        {
            var inserted = await _unitOfWork.Repository<Member>().AddAsync(member) != null;
            return inserted;

        }
        public async Task<IList<Member>> GetMemberAsync()
        {

            var members = await _unitOfWork.Repository<Member>()
               .Query()
               .ToListAsync();

            return members;
        }
        public async Task<bool> EditMemberAsync(Member member)
        {

            if (member.MemberName != "")
            {
                var memberFromDb = await _unitOfWork.Repository<Member>()
                    .FindAsync(a => a.MemberID == member.MemberID);
                memberFromDb.MemberName = member.MemberName;

                var updated = await _unitOfWork.Repository<Member>()
                    .UpdateAsync(memberFromDb) != null;
                return updated;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> RemoveMemberAsync(int memberId)
        {


            return await _unitOfWork.Repository<Member>()
                .DeleteAsync(new Member() { MemberID = memberId }) > 0;
        }
        public void GetMembers()
        {}
        public void PostMembers()
        {}
        public void PutMembers()
        {}
        public void DeleteMembers()
        {}
    }
}
 
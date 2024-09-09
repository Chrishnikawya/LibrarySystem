using Microsoft.EntityFrameworkCore;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using LibrarySystem.ViewModels;
namespace LibrarySystem.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public MemberService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Add a Member
        /// </summary>
        /// <param name="memberViewModel"></param>
        /// <returns></returns>
        public async Task<bool> AddMemberAsync(MemberViewModel memberViewModel)
        {
            try
            {
                var member = new Member
                {
                    MemberName = memberViewModel.MemberName,
                    MemberEmail = memberViewModel.MemberEmail,
                    MemberPhoneNumber = memberViewModel.MemberPhoneNumber,
                    DateCreated = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                    DateModified = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                };
                var inserted = await _unitOfWork.Repository<Member>().AddAsync(member) != null;
                return inserted;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
         /// <summary>
         /// Get Member
         /// </summary>
         /// <returns></returns>
        public async Task<IList<MemberViewModel>> GetMemberAsync()
        {
            try
            {
                var members = await _unitOfWork.Repository<Member>()
                .Query()
                 .ToListAsync();

                return members.Select(m => new MemberViewModel
                {
                    MemberID = m.Id,
                    MemberName = m.MemberName,
                    MemberEmail = m.MemberEmail,
                    MemberPhoneNumber = m.MemberPhoneNumber
                }).ToList();
            }
           
            catch (Exception ex)
            {
                throw ex;
            }
        }
      /// <summary>
      /// Edit Member
      /// </summary>
      /// <param name="memberViewModel"></param>
      /// <returns></returns>
        public async Task<bool> EditMemberAsync(MemberViewModel memberViewModel)
        {
            try
            {
                var member = new Member
                {
                    Id = memberViewModel.MemberID,
                    MemberName = memberViewModel.MemberName,
                    MemberEmail = memberViewModel.MemberEmail,
                    MemberPhoneNumber = memberViewModel.MemberPhoneNumber,
                    DateModified = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                };
                var updated = await _unitOfWork.Repository<Member>()
               .UpdateAsync(member) != null;
                return updated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       /// <summary>
       /// Remove Member
       /// </summary>
       /// <param name="memberId"></param>
       /// <returns></returns>
        public async Task<bool> RemoveMemberAsync(int memberId)
        {
            try
            {
                return await _unitOfWork.Repository<Member>()
                .DeleteAsync(new Member() { Id = memberId }) > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}


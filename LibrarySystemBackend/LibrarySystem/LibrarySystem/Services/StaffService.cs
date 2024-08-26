using Microsoft.EntityFrameworkCore;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using LibrarySystem.ViewModels;

namespace LibrarySystem.Services
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public StaffService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add a Staff
        /// </summary>
        /// <param name="staffViewModel"></param>
        /// <returns></returns>
        public async Task<bool> AddStaffAsync(StaffViewModel staffViewModel)
        {
            try
            {
                var staff = new Staff
                {
                    StaffName = staffViewModel.StaffName,
                    StaffEmail = staffViewModel.StaffEmail,
                    EnrollmentDate = staffViewModel.EnrollmentDate,
                    StaffID = staffViewModel.StaffID
                };
                var inserted = await _unitOfWork.Repository<Staff>().AddAsync(staff) != null;
                return inserted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Add Staff
        /// </summary>
        /// <returns></returns>
        public async Task<IList<StaffViewModel>> GetStaffAsync()
        {
            try
            {
                var staffList = await _unitOfWork.Repository<Staff>()
                .Query()
                .ToListAsync();

                return staffList.Select(s => new StaffViewModel
                {
                    StaffName = s.StaffName,
                    StaffEmail = s.StaffEmail,
                    EnrollmentDate = s.EnrollmentDate,
                    StaffID = s.StaffID
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
          /// <summary>
          /// Get Staff
          /// </summary>
          /// <param name="staffViewModel"></param>
          /// <returns></returns>
        public async Task<bool> EditStaffAsync(StaffViewModel staffViewModel)
        {
            try
            {
                var staff = new Staff
                {
                    StaffName = staffViewModel.StaffName,
                    StaffEmail = staffViewModel.StaffEmail,
                    EnrollmentDate = staffViewModel.EnrollmentDate,
                    StaffID = staffViewModel.StaffID
                };
                var updated = await _unitOfWork.Repository<Staff>()
               .UpdateAsync(staff) != null;
                return updated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         /// <summary>
         /// Edit Staff
         /// </summary>
         /// <param name="staffId"></param>
         /// <returns></returns>
        public async Task<bool> RemoveStaffAsync(int staffId)
        {
            try
            {
                return await _unitOfWork.Repository<Staff>()
                .DeleteAsync(new Staff() { StaffID = staffId }) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Staff
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
    }
}

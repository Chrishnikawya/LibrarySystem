using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{  
    public class StaffService:IStaffService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public StaffService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddStaffAsync(Staff staff)
        {
            var inserted = await _unitOfWork.Repository<Staff>().AddAsync(staff) != null;
            return inserted;

        }
        public async Task<IList<Staff>> GetStaffAsync()
        {

            var staffs = await _unitOfWork.Repository<Staff>()
               .Query()
               .ToListAsync();

            return staffs;
        }
        public async Task<bool> EditStaffAsync(Staff staff)
        {

            if (staff.StaffName != "")
            {
                var staffFromDb = await _unitOfWork.Repository<Staff>()
                    .FindAsync(a => a.StaffID == staff.StaffID);
                staffFromDb.StaffName = staff.StaffName;

                var updated = await _unitOfWork.Repository<Staff>()
                    .UpdateAsync(staffFromDb) != null;
                return updated;
            }
            else
            {
                return false;
            }

        }
        public async Task<bool> RemoveStaffAsync(int staffId)
        {


            return await _unitOfWork.Repository<Staff>()
                .DeleteAsync(new Staff() { StaffID = staffId }) > 0;
        }
        public void GetStaffs()
        {}
        public void PostStaffs()
        {}
        public void PutStaffs()
        {}
        public void DeleteStaffs()
        {}
    }
}

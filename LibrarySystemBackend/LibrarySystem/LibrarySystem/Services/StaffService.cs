using LibrarySystem.Interfaces;
using LibrarySystem.Repositories;

namespace LibrarySystem.Services
{  
    public class StaffService:IStaffService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public StaffService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void GetStaffs()
        { }
        public void PostStaffs()
        { }
        public void PutStaffs()
        { }
        public void DeleteStaffs()
        { }
    }
}

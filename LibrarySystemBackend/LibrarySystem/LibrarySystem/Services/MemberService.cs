using LibrarySystem.Interfaces;
using LibrarySystem.Repositories;

namespace LibrarySystem.Services
{
    public class MemberService:IMemberService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public MemberService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void GetMembers()
        { }
        public void PostMembers()
        { }
        public void PutMembers()
        { }
        public void DeleteMembers()
        { }
    }
}

using LibrarySystem.Interfaces;
using LibrarySystem.Repositories;

namespace LibrarySystem.Services
{
    public class ResevationService:IResevationService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public ResevationService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void GetResevations()
        { }
        public void PostResevations()
        { }
        public void PutResevations()
        { }
        public void DeleteResevations()
        { }
    }
}

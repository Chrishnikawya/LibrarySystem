using LibrarySystem.Interfaces;
using LibrarySystem.Repositories;

namespace LibrarySystem.Services
{
    public class AuthorService:IAuthorService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public AuthorService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void GetAuthors()
        {}
        public void PostAuthors()
        { }
        public void PutAuthors()
            { }
        public void DeleteAuthors()
        { }
    }
}

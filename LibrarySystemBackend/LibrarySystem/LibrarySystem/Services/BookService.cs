using LibrarySystem.Interfaces;
using LibrarySystem.Repositories;

namespace LibrarySystem.Services
{
    public class BookService:IBookService  
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public BookService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void GetBooks()
        { }
        public void PostBooks()
        { }
        public void PutBooks()
        { }
        public void DeleteBooks()
        { }
    }
}

    
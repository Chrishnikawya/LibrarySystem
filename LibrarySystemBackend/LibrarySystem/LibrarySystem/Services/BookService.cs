using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
using LibrarySystem.Interfaces;
using LibrarySystem.Repositories;

namespace LibrarySystem.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public BookService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddBookAsync(Book book)
        {
            var inserted = await _unitOfWork.Repository<Book>().AddAsync(book) != null;
            return inserted;
        }
        public async Task<IList<Book>> GetBookAsync()
        {

            var books = await _unitOfWork.Repository<Book>()
               .Query()
               .ToListAsync();

            return books;
        }
        public async Task<bool> EditBookAsync(Book book)
        {

            if (book.BookName != "")
            {
                var bookFromDb = await _unitOfWork.Repository<Book>()
                    .FindAsync(a => a.BookID == book.BookID);
                bookFromDb.BookName = book.BookName;

                var updated = await _unitOfWork.Repository<Book>()
                    .UpdateAsync(bookFromDb) != null;
                return updated;
            }
            else
            {
                return false;
            }

        }
        public async Task<bool> RemoveBookAsync(int BookId)
        {


            return await _unitOfWork.Repository<Book>()
                .DeleteAsync(new Book() { BookID = BookId }) > 0;
        }

        public void GetBooks()
        {}
        public void PostBooks()
        {}
        public void PutBooks()
        {}
        public void DeleteBooks()
        {}
    }
}



















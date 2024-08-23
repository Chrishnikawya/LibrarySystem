using Microsoft.EntityFrameworkCore;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using LibrarySystem.ViewModels;
namespace LibrarySystem.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public BookService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Add an Author
        /// </summary>
        /// <param name="bookViewModel"></param>
        /// <returns></returns>
        public async Task<bool> AddBookAsync(BookViewModel bookViewModel)
        {
            try
            {
                var books = new Book
                {
                    BookID = bookViewModel.BookID,
                    BookName = bookViewModel.BookName,
                    AuthorID = bookViewModel.AuthorID,
                    Category = bookViewModel.Category,
                    PublisherID = bookViewModel.PublisherID
                };
                var inserted = await _unitOfWork.Repository<Book>().AddAsync(books) != null;
                return inserted;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IList<BookViewModel>> GetBookAsync()
        {
            try
            {
                var books = await _unitOfWork.Repository<Book>()
                .Query()
                 .ToListAsync();

                return books.Select(a => new BookViewModel
                {
                   BookID = a.BookID,
                   BookName = a.BookName,
                   AuthorID = a.AuthorID,
                   Category = a.Category,
                   PublisherID = a.PublisherID
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> EditBookAsync(BookViewModel bookViewModel)
        {
            try
            {
                var books = new Book
                {
                    BookID = bookViewModel.BookID,
                    BookName = bookViewModel.BookName,
                    AuthorID = bookViewModel.AuthorID,
                    Category = bookViewModel.Category,
                    PublisherID = bookViewModel.PublisherID
                };
                var updated = await _unitOfWork.Repository<Book>()
               .UpdateAsync(books) != null;
                return updated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> RemoveBookAsync(int bookId)
        {
            try
            {
                return await _unitOfWork.Repository<Book>()
                .DeleteAsync(new Book() { BookID = bookId }) > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}























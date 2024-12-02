using Microsoft.EntityFrameworkCore;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using LibrarySystem.ViewModels;
using LibrarySystem.DbContext;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibrarySystem.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly LibraryContext _context;
        public BookService(IUnitOfWorkRepository unitOfWork,LibraryContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        /// <summary>
        /// Add an Book
        /// </summary>
        /// <param name="bookViewModel"></param>
        /// <returns></returns>
        public async Task<bool> AddBookAsync(BookViewModel bookViewModel)
        {
            try
            {
                var books = new Book
                {
                    BookName = bookViewModel.BookName,
                    AuthorID = bookViewModel.AuthorID,
                    CategoryID = bookViewModel.CategoryID,
                    PublisherID = bookViewModel.PublisherID,
                    DateCreated = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                    DateModified = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                };
                var inserted = await _unitOfWork.Repository<Book>().AddAsync(books) != null;
                return inserted;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        /// <summary>
        /// Get Book
        /// </summary>
        /// <returns></returns>
        public async Task<IList<BookViewModel>> GetBookAsync()
        {
            try
            {
                var books = await _unitOfWork.Repository<Book>()
                .Query()
                 .ToListAsync();

                return books.Select(b => new BookViewModel
                {
                   BookID = b.Id,
                   BookName = b.BookName,
                   AuthorID = b.AuthorID,
                   CategoryID = b.CategoryID,
                   PublisherID = b.PublisherID
                })
                    .OrderBy(b => b.BookName)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    /// <summary>
    /// Edit Book
    /// </summary>
    /// <param name="bookViewModel"></param>
    /// <returns></returns>
        public async Task<bool> EditBookAsync(BookViewModel bookViewModel)
        {
            try
            {
                var books = new Book
                {
                    Id = bookViewModel.BookID,
                    BookName = bookViewModel.BookName,
                    AuthorID = bookViewModel.AuthorID,
                    CategoryID = bookViewModel.CategoryID,
                    PublisherID = bookViewModel.PublisherID,
                    DateModified = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
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
      /// <summary>
      /// Remove Book
      /// </summary>
      /// <param name="bookId"></param>
      /// <returns></returns>
        public async Task<bool> RemoveBookAsync(int bookId)
        {
            try
            {
                return await _unitOfWork.Repository<Book>()
                .DeleteAsync(new Book() { Id = bookId }) > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Stored Procedure
        /// </summary>
        /// <returns></returns>
        public async Task<IList<BookDetailsViewModel>> GetBookDetailsAsync()
        {
            try
            {
                var bookDetails = await _context.BookDetails
                 .FromSqlRaw("EXEC BookDetails")
                 .ToListAsync();
                return bookDetails.Select(b => new BookDetailsViewModel
                {
                    BookID = b.Id,
                    BookName = b.BookName,
                    AuthorID = b.AuthorID,
                    CategoryID = b.CategoryID,
                    PublisherID = b.PublisherID,
                    AuthorName = b.AuthorName,
                    PublisherName = b.PublisherName,
                    CategoryName = b.CategoryName
                })
                    .OrderBy(b => b.BookName)
                    .ToList();
                //return bookDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        /// <summary>
        /// Views
        /// </summary>
        /// <returns></returns>
        public async Task<List<BookDetails>> GetBookDetailsViewAsync()
        {
            try
            {
                return await _context.Set<BookDetails>().FromSqlRaw("SELECT * FROM BookDetailsView").ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}























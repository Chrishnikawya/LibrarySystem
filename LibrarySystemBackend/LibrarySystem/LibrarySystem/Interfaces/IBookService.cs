using LibrarySystem.Models;

namespace LibrarySystem.Interfaces
{
    public interface IBookService
    {
        Task<bool> AddBookAsync(Book book);
        //Task<IList<Book>> AddBookAsync();
        Task<bool> EditBookAsync(Book book);
        Task<bool> RemoveBookAsync(int BookId);
        Task<IList<Book>> GetBookAsync();

    }
}

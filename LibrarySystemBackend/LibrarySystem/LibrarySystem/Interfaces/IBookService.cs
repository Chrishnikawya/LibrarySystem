using LibrarySystem.Models;
using LibrarySystem.ViewModels;

namespace LibrarySystem.Interfaces
{
    public interface IBookService
    {
        Task<bool> AddBookAsync(BookViewModel bookViewModel);
        Task<bool> EditBookAsync(BookViewModel bookViewModel);
        Task<bool> RemoveBookAsync(int bookId);
        Task<IList<BookViewModel>> GetBookAsync();
        Task<List<BookDetails>> GetBookDetailsAsync();

    }
}

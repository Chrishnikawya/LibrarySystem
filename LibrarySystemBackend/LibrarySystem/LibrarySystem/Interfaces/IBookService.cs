using LibrarySystem.ViewModels;

namespace LibrarySystem.Interfaces
{
    public interface IBookService
    {
        Task<bool> AddBookAsync(BookViewModel bookViewModel);
        //Task<IList<Book>> AddBookAsync();
        Task<bool> EditBookAsync(BookViewModel bookViewModel);
        Task<bool> RemoveBookAsync(int BookId);
        Task<IList<BookViewModel>> GetBookAsync();

    }
}

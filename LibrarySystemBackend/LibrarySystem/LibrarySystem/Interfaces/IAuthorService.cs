using LibrarySystem.ViewModels;
using LibrarySystem.Models;

namespace LibrarySystem.Interfaces
{
    public interface IAuthorService
    {
        Task<bool> AddAuthorAsync(AuthorViewModel authorViewModel);
        Task<IList<AuthorViewModel>> GetAuthorAsync();      
        Task<bool>EditAuthorAsync(AuthorViewModel authorViewModel);
        Task<bool> RemoveAuthorAsync(int authorId);
    }
}



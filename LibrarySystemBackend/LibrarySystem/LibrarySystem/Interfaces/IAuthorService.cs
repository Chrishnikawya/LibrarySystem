using LibrarySystem.Models;

namespace LibrarySystem.Interfaces
{
    public interface IAuthorService
    {
        Task<bool> AddAuthorAsync(Author author);
        Task<IList<Author>> GetAuthorAsync();      
        Task<bool>EditAuthorAsync(Author author);
        Task<bool> RemoveAuthorAsync(int authorId);
    }
}



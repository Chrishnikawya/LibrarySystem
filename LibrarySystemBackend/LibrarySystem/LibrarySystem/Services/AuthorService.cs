using Microsoft.EntityFrameworkCore;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
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

        public async Task<bool> AddAuthorAsync(Author author)
        {
            var inserted = await _unitOfWork.Repository<Author>().AddAsync(author) != null;
            return inserted;

        }
        public async Task<IList<Author>> GetAuthorAsync()
        {

            var authors = await _unitOfWork.Repository<Author>()
               .Query()
               .ToListAsync();

            return authors;
        }
        public async Task<bool> EditAuthorAsync(Author author)
        {

            if (author.AuthorName != "")
            {
                var authorFromDb = await _unitOfWork.Repository<Author>()
                    .FindAsync(a => a.AuthorID == author.AuthorID);
                authorFromDb.AuthorName = author.AuthorName;

                var updated = await _unitOfWork.Repository<Author>()
                    .UpdateAsync(authorFromDb) != null;
                return updated;
            }
            else
            {
                return false;
            }

        }
        public async Task<bool>RemoveAuthorAsync(int authorId)
        {


            return await _unitOfWork.Repository<Author>()
                .DeleteAsync(new Author() { AuthorID = authorId }) > 0;
        }
        
        
    }
}

       
    
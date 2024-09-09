using Microsoft.EntityFrameworkCore;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using LibrarySystem.ViewModels;
namespace LibrarySystem.Services
{
    public class AuthorService:IAuthorService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public AuthorService(IUnitOfWorkRepository unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Add an Author
        /// </summary>
        /// <param name="authorViewModel"></param>
        /// <returns></returns>
        public async Task<bool> AddAuthorAsync(AuthorViewModel authorViewModel)
        {
            try
            {
                var authors = new Author
                {
                    AuthorAddress = authorViewModel.AuthorAddress,
                    AuthorName = authorViewModel.AuthorName,
                    AuthorEmail = authorViewModel.AuthorEmail,
                    AuthorPhoneNumber = authorViewModel.AuthorPhoneNumber,
                    DateCreated = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                    DateModified = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                };
                var inserted = await _unitOfWork.Repository<Author>().AddAsync(authors) != null;
                return inserted;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
       /// <summary>
       /// Get Author
       /// </summary>
       /// <returns></returns>
        public async Task<IList<AuthorViewModel>> GetAuthorAsync()
        {
            try
            {
                var authors = await _unitOfWork.Repository<Author>()
                .Query()
                 .ToListAsync();

                return authors.Select(a => new AuthorViewModel
                {
                    AuthorAddress = a.AuthorAddress,
                    AuthorName = a.AuthorName,
                    AuthorEmail = a.AuthorEmail,
                    AuthorID = a.Id,
                    AuthorPhoneNumber = a.AuthorPhoneNumber
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Author
        /// </summary>
        /// <param name="authorViewModel"></param>
        /// <returns></returns>
        public async Task<bool> EditAuthorAsync(AuthorViewModel authorViewModel)
        {
            try
            {
                var authors = new Author
                {
                    AuthorAddress = authorViewModel.AuthorAddress,
                    AuthorName = authorViewModel.AuthorName,
                    AuthorEmail = authorViewModel.AuthorEmail,
                    Id = authorViewModel.AuthorID,
                    AuthorPhoneNumber = authorViewModel.AuthorPhoneNumber,
                    DateModified = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                };
                var updated = await _unitOfWork.Repository<Author>()
               .UpdateAsync(authors) != null;
                return updated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       /// <summary>
       /// Remove Author
       /// </summary>
       /// <param name="authorId"></param>
       /// <returns></returns>
        public async Task<bool>RemoveAuthorAsync(int authorId)
        {
            try
            {
                return await _unitOfWork.Repository<Author>()
                .DeleteAsync(new Author() { Id = authorId }) > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

       
    
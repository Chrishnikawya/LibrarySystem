using Microsoft.EntityFrameworkCore;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using LibrarySystem.ViewModels;
namespace LibrarySystem.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public CategoryService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Add Category
        /// </summary>
        /// <param name="categoryViewModel"></param>
        /// <returns></returns>
        public async Task<bool> AddCategoryAsync(CategoryViewModel categoryViewModel)
        {
            try
            {
                var categorys = new Category
                {                   
                    CategoryName = categoryViewModel.CategoryName,
                    DateCreated = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                    DateModified = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                };
                var inserted = await _unitOfWork.Repository<Category>().AddAsync(categorys) != null;
                return inserted;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get Category
        /// </summary>
        /// <returns></returns>
        public async Task<IList<CategoryViewModel>> GetCategoryAsync()
        {
            try
            {
                var categorys = await _unitOfWork.Repository<Category>()
                .Query()
                 .ToListAsync();

                return categorys.Select(c => new CategoryViewModel
                {
                    CategoryID = c.Id,
                    CategoryName = c.CategoryName
                })
                    .OrderBy(c => c.CategoryName)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Category
        /// </summary>
        /// <param name="categoryViewModel"></param>
        /// <returns></returns>
        public async Task<bool> EditCategoryAsync(CategoryViewModel categoryViewModel)
        {
            try
            {
                var categorys = new Category
                {     
                    Id = categoryViewModel.CategoryID,
                    CategoryName = categoryViewModel.CategoryName,
                    DateModified = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                };
                var updated = await _unitOfWork.Repository<Category>()
               .UpdateAsync(categorys) != null;
                return updated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Remove Category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<bool> RemoveCategoryAsync(int categoryId)
        {
            try
            {
                return await _unitOfWork.Repository<Category>()
                .DeleteAsync(new Category() { Id = categoryId }) > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}



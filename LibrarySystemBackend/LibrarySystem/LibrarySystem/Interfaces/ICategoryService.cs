using LibrarySystem.ViewModels;


namespace LibrarySystem.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> AddCategoryAsync(CategoryViewModel categoryViewModel);
        Task<IList<CategoryViewModel>> GetCategoryAsync();
        Task<bool> EditCategoryAsync(CategoryViewModel categoryViewModel);
        Task<bool> RemoveCategoryAsync(int categoryId);
    }
}

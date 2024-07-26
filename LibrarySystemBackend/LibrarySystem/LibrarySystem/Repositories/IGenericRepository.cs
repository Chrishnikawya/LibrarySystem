
namespace LibrarySystem.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
            Task<T> GetByIdAsync(int id);
            Task<ICollection<T>> GetAllAsync();
            Task<T> AddAsync(T entity);
            Task<int> DeleteAsync(T entity);
            Task<T> UpdateAsync(T entity);
        
    }
}



using System.Linq.Expressions;

namespace LibrarySystem.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
            Task<T> GetByIdAsync(int id);
            Task<ICollection<T>> GetAllAsync();
            Task<T> AddAsync(T entity);
            Task<int> DeleteAsync(T entity);
            Task<T> UpdateAsync(T entity);
            Task<T> GetByUniqueIdAsync(string id);
            Task<ICollection<T>> GetAll();

        IQueryable<T> Query();
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

    }
}


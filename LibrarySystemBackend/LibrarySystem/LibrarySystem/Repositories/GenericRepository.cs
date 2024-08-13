using Microsoft.EntityFrameworkCore;
using LibrarySystem.Repositories;
using LibrarySystem.DbContext;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq.Expressions;

namespace LibrarySystem.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LibraryContext _dbContext;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public GenericRepository(LibraryContext context)
        {
            _dbContext = context;
            _unitOfWork = new UnitOfWorkRepository(context);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().AddAsync(entity);
            return (await _unitOfWork.Commit()) > 0 ? entity : null;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await _unitOfWork.Commit();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                return null;
            }
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            var res = await _unitOfWork.Commit();

            return res > 0 ? entity : null;
        }

        public IQueryable<T> Query()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }
    }
}




 
       

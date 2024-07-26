using LibrarySystem.Repositories;
using LibrarySystem.DbContext;
namespace LibrarySystem.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly LibraryContext _dbContext;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public Dictionary<Type, object> Repositories
        {
            get { return _repositories; }
            set { Repositories = value; }
        }

        public UnitOfWorkRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
           
        }
        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new GenericRepository<T>(_dbContext);
            Repositories.Add(typeof(T), repo);
            return repo;
        }
        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}




        

   
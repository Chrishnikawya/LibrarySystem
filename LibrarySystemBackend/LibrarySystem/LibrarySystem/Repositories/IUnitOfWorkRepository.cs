namespace LibrarySystem.Repositories
{
    public interface IUnitOfWorkRepository
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task<int> Commit();
    }
}

    
       
    

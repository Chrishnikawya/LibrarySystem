using LibrarySystem.Models;

namespace LibrarySystem.Interfaces
{

    public interface IPublisherService
    {
        Task<bool> AddPublisherAsync(Publisher publisher);
        Task<IList<Publisher>> GetPublisherAsync();
        Task<bool> EditPublisherAsync(Publisher publisher);
        Task<bool> RemovePublisherAsync(int publisherId);
    }
}

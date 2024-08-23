using LibrarySystem.ViewModels;
using LibrarySystem.Models;

namespace LibrarySystem.Interfaces
{

    public interface IPublisherService
    {
        Task<bool> AddPublisherAsync(PublisherViewModel publisherViewModel);
        Task<IList<PublisherViewModel>> GetPublisherAsync();
        Task<bool> EditPublisherAsync(PublisherViewModel publisherViewModel);
        Task<bool> RemovePublisherAsync(int publisherId);
    }
}

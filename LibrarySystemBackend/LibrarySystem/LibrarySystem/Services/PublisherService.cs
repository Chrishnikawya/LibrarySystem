using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class PublisherService:IPublisherService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public PublisherService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddPublisherAsync(Publisher publisher)
        {
            var inserted = await _unitOfWork.Repository<Publisher>().AddAsync(publisher) != null;
            return inserted;

        }
        public async Task<IList<Publisher>> GetPublisherAsync()
        {

            var publishers = await _unitOfWork.Repository<Publisher>()
               .Query()
               .ToListAsync();

            return publishers;
        }
        public async Task<bool> EditPublisherAsync(Publisher publisher)
        {

            if (publisher.PublisherName != "")
            {
                var publisherFromDb = await _unitOfWork.Repository<Publisher>()
                    .FindAsync(a => a.PublisherID == publisher.PublisherID);
                publisherFromDb.PublisherName = publisher.PublisherName;

                var updated = await _unitOfWork.Repository<Publisher>()
                    .UpdateAsync(publisherFromDb) != null;
                return updated;
            }
            else
            {
                return false;
            }
 }
        public async Task<bool> RemovePublisherAsync(int publisherId)
        {


            return await _unitOfWork.Repository<Publisher>()
                .DeleteAsync(new Publisher() { PublisherID = publisherId }) > 0;
        }
        public void GetPublishers()
        {}
        public void PostPublishers()
        {}
        public void PutPublishers()
        {}
        public void DeletePublishers()
        {}
    }
}

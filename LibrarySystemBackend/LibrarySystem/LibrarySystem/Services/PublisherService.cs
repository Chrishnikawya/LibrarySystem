using LibrarySystem.Interfaces;
using LibrarySystem.Repositories;

namespace LibrarySystem.Services
{
    public class PublisherService:IPublisherService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public PublisherService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void GetPublishers()
        { }
        public void PostPublishers()
        { }
        public void PutPublishers()
        { }
        public void DeletePublishers()
        { }
    }
}

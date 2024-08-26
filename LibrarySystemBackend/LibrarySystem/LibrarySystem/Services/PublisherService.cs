using Microsoft.EntityFrameworkCore;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using LibrarySystem.ViewModels;
namespace LibrarySystem.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public PublisherService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Add a Publisher
        /// </summary>
        /// <param name="publisherViewModel"></param>
        /// <returns></returns>
        public async Task<bool> AddPublisherAsync(PublisherViewModel publisherViewModel)
        {
            try
            {
                var publisher = new Publisher
                {
                    PublisherAddress = publisherViewModel.PublisherAddress,
                    PublisherName = publisherViewModel.PublisherName,
                    PublisherEmail = publisherViewModel.PublisherEmail,
                    PublisherID = publisherViewModel.PublisherID,
                    PublisherPhoneNumber = publisherViewModel.PublisherPhoneNumber
                };
                var inserted = await _unitOfWork.Repository<Publisher>().AddAsync(publisher) != null;
                return inserted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Add Publisher
        /// </summary>
        /// <returns></returns>
        public async Task<IList<PublisherViewModel>> GetPublisherAsync()
        {
            try
            {
                var publishers = await _unitOfWork.Repository<Publisher>()
                .Query()
                 .ToListAsync();

                return publishers.Select(p => new PublisherViewModel
                {
                    PublisherAddress = p.PublisherAddress,
                    PublisherName = p.PublisherName,
                    PublisherEmail = p.PublisherEmail,
                    PublisherID = p.PublisherID,
                    PublisherPhoneNumber = p.PublisherPhoneNumber
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get Publisher
        /// </summary>
        /// <param name="publisherViewModel"></param>
        /// <returns></returns>
        public async Task<bool> EditPublisherAsync(PublisherViewModel publisherViewModel)
        {
            try
            {
                var publisher = new Publisher
                {
                    PublisherAddress = publisherViewModel.PublisherAddress,
                    PublisherName = publisherViewModel.PublisherName,
                    PublisherEmail = publisherViewModel.PublisherEmail,
                    PublisherID = publisherViewModel.PublisherID,
                    PublisherPhoneNumber = publisherViewModel.PublisherPhoneNumber
                };
                var updated = await _unitOfWork.Repository<Publisher>()
               .UpdateAsync(publisher) != null;
                return updated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Publisher
        /// </summary>
        /// <param name="publisherId"></param>
        /// <returns></returns>
        public async Task<bool> RemovePublisherAsync(int publisherId)
        {
            try
            {
                return await _unitOfWork.Repository<Publisher>()
                .DeleteAsync(new Publisher() { PublisherID = publisherId }) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Publisher
        /// </summary>
        /// <param name="publisherId"></param>
        /// <returns></returns>
    }
}


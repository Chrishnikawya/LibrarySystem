using Microsoft.EntityFrameworkCore;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using LibrarySystem.ViewModels;

namespace LibrarySystem.Services
{
    public class ResevationService : IResevationService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public ResevationService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add a Resevation
        /// </summary>
        /// <param name="resevationViewModel"></param>
        /// <returns></returns>
        public async Task<bool> AddResevationAsync(ResevationViewModel resevationViewModel)
        {
            try
            {
                var resevations = new Resevation
                {
                    ReservationDate = resevationViewModel.ReservationDate,
                    Status = resevationViewModel.Status,
                    MemberID = resevationViewModel.MemberID,
                    StaffID = resevationViewModel.StaffID,
                    BookID = resevationViewModel.BookID
                };
                var inserted = await _unitOfWork.Repository<Resevation>().AddAsync(resevations) != null;
                return inserted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Add Resevation
        /// </summary>
        /// <returns></returns>
        public async Task<IList<ResevationViewModel>> GetResevationAsync()
        {
            try
            {
                var resevations = await _unitOfWork.Repository<Resevation>()
                .Query()
                .ToListAsync();

                return resevations.Select(r => new ResevationViewModel
                {
                    ReservationID = r.ReservationID,
                    ReservationDate = r.ReservationDate,
                    Status = r.Status,
                    MemberID = r.MemberID,
                    StaffID = r.StaffID,
                    BookID = r.BookID
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        /// <summary>
        /// Edit Resevation
        /// </summary>
        /// <param name="resevationId"></param>
        /// <returns></returns>
        public async Task<bool> EditResevationAsync(ResevationViewModel resevationViewModel)
        {
            try
            {
                var resevations = new Resevation
                {
                    ReservationDate = resevationViewModel.ReservationDate,
                    Status = resevationViewModel.Status,
                    MemberID = resevationViewModel.MemberID,
                    StaffID = resevationViewModel.StaffID,
                    BookID = resevationViewModel.BookID
                };
                var updated = await _unitOfWork.Repository<Resevation>()
               .UpdateAsync(resevations) != null;
                return updated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Delete Resevation
        /// </summary>
        /// <param name="resevationId"></param>
        /// <returns></returns>
        public async Task<bool> RemoveResevationAsync(int resevationId)
        {
            try
            {
                return await _unitOfWork.Repository<Resevation>()
                .DeleteAsync(new Resevation() { ReservationID = resevationId }) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}


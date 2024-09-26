using Microsoft.EntityFrameworkCore;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using LibrarySystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.DbContext;

namespace LibrarySystem.Services
{
    public class ResevationService : IResevationService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly LibraryContext _context;

        public ResevationService(IUnitOfWorkRepository unitOfWork,LibraryContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
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
                var resevations = new Reservation
                {
                    ReservationDate =new DateTime( resevationViewModel.ReservationDate.Ticks,DateTimeKind.Utc),
                    Status = resevationViewModel.Status,
                    MemberID = resevationViewModel.MemberID,
                    StaffID = resevationViewModel.StaffID,
                    BookID = resevationViewModel.BookID,
                    DateCreated = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                    DateModified = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                };
                var inserted = await _unitOfWork.Repository<Reservation>().AddAsync(resevations) != null;
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
                var resevations = await _unitOfWork.Repository<Reservation>()
                .Query()
                .ToListAsync();

                return resevations.Select(r => new ResevationViewModel
                {
                    ReservationID = r.Id,
                    ReservationDate = new DateTime(r.ReservationDate.Ticks,DateTimeKind.Utc),
                    Status = r.Status,
                    MemberID = r.MemberID,
                    StaffID = r.StaffID,
                    BookID = r.BookID
                })
                    .OrderBy(r => r.ReservationDate)
                    .ToList();
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
                var resevations = new Reservation
                {
                    Id = resevationViewModel.ReservationID,
                    ReservationDate = new DateTime (resevationViewModel.ReservationDate.Ticks, DateTimeKind.Utc), 
                    Status = resevationViewModel.Status,
                    MemberID = resevationViewModel.MemberID,
                    StaffID = resevationViewModel.StaffID,
                    BookID = resevationViewModel.BookID,
                    DateModified = new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc),
                };
                var updated = await _unitOfWork.Repository<Reservation>()
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
                return await _unitOfWork.Repository<Reservation>()
                .DeleteAsync(new Reservation() { Id = resevationId }) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ReservationDetails>> GetReservationDetailsAsync()
        {
            var reservationDetails = await _context.ReservationDetails
                .FromSqlRaw("EXEC GetReservationDetails") 
                .ToListAsync();

            return reservationDetails;
        }

        public async Task<List<ReservationDetails>> GetReservationDetailsViewAsync()
        {
            return await _context.Set<ReservationDetails>().FromSqlRaw("SELECT * FROM ReservationDetailsView").ToListAsync();
        }

    }
}


using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class ResevationService:IResevationService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public ResevationService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddResevationAsync(Resevation resevation)
        {
            var inserted = await _unitOfWork.Repository<Resevation>().AddAsync(resevation) != null;
            return inserted;

        }
        public async Task<IList<Resevation>> GetResevationAsync()
        {

            var resevations = await _unitOfWork.Repository<Resevation>()
               .Query()
               .ToListAsync();

            return resevations;
        }
        public async Task<bool> EditResevationAsync(Resevation resevation)
        {

            if (resevation.ReservationID != null)
            {
                var resevationFromDb = await _unitOfWork.Repository<Resevation>()
                    .FindAsync(a => a.ReservationID == resevation.ReservationID);
                resevationFromDb.ReservationID = resevation.ReservationID;

                var updated = await _unitOfWork.Repository<Resevation>()
                    .UpdateAsync(resevationFromDb) != null;
                return updated;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> RemoveResevationAsync(int resevationId)
        {


            return await _unitOfWork.Repository<Resevation>()
                .DeleteAsync(new Resevation() { ReservationID = resevationId }) > 0;
        }
        public void GetResevations()
        {}

        public void PostResevations()
        {}
        public void PutResevations()
        {}
        public void DeleteResevations()
        {}
    }
}

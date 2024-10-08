﻿using LibrarySystem.Models;
using LibrarySystem.ViewModels;

namespace LibrarySystem.Interfaces
{
    public interface IResevationService
    {
        Task<bool> AddResevationAsync(ResevationViewModel resevationVIewModel);
        Task<IList<ResevationViewModel>> GetResevationAsync();
        Task<bool> EditResevationAsync(ResevationViewModel resevationViewModel);
        Task<bool> RemoveResevationAsync(int resevationId);
        Task<List<ReservationDetails>> GetReservationDetailsAsync();
        Task<List<ReservationDetails>> GetReservationDetailsViewAsync();
    }
}

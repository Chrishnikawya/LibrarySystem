using LibrarySystem.Models;

namespace LibrarySystem.Interfaces
{
    public interface IResevationService
    {
        Task<bool> AddResevationAsync(Resevation resevation);
        Task<IList<Resevation>> GetResevationAsync();
        Task<bool> EditResevationAsync(Resevation resevation);
        Task<bool> RemoveResevationAsync(int resevationId);
    }
}

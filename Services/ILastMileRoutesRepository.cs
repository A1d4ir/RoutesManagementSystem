using RoutesManagementSystem.API.Entities;

namespace RoutesManagementSystem.API.Services
{
    public interface ILastMileRoutesRepository
    {
        Task<int> AddLastMileRoute(
            RoutesManagementSystem.API.Entities.Route route,
            LastMileRoute lastMileRoute
        );
        Task<RoutesManagementSystem.API.Entities.Route?> GetLastMileRouteById(int id);
        Task<bool> SaveChangesAsync();
    }
}

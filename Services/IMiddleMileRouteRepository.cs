using RoutesManagementSystem.API.Entities;

namespace RoutesManagementSystem.API.Services
{
    public interface IMiddleMileRouteRepository
    {
        Task<int> AddMiddleMileRoute(Entities.Route route, MiddleMileRoute middleMileRoute);
        Task<Entities.Route?> GetMiddleMileRouteById(int id);
        Task<bool> SaveChangesAsync();
    }
}

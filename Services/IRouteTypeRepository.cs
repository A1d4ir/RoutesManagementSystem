using RoutesManagementSystem.API.Entities;

namespace RoutesManagementSystem.API.Services
{
    public interface IRouteTypeRepository
    {
        Task<RouteType?> GetRouteTypeAsync(int id);
    }
}

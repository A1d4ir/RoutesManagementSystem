namespace RoutesManagementSystem.API.Services
{
    public interface IRouteService
    {
        Task<(IEnumerable<Entities.Route>, PaginationMetadata)> GetRoutesAsync(
            string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Entities.Route?> RouteExist(int id);
        void DeleteRoute(Entities.Route route);
        Task<bool> SaveChangesAsync();
    }
}

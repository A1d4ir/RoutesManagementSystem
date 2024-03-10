using Microsoft.EntityFrameworkCore;
using RoutesManagementSystem.API.DbContexts;
using RoutesManagementSystem.API.Entities;

namespace RoutesManagementSystem.API.Services
{
    public class MiddleMileRouteRepository : IMiddleMileRouteRepository
    {
        private readonly RoutesManagerDbContext _context;

        public MiddleMileRouteRepository(RoutesManagerDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddMiddleMileRoute(Entities.Route route, MiddleMileRoute middleMileRoute)
        {
            route.MiddleMileRoute = middleMileRoute;
            route.CreatedAt = DateTime.Now;
            _context.Routes.Add(route);

            try
            {
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return route.Id;
        }

        public async Task<Entities.Route?> GetMiddleMileRouteById(int id)
        {
            var result = await _context.Routes
                .Include(r => r.MiddleMileRoute)
                .Include(r => r.RouteType)
                .Where(r => r.Id == id && r.DeletedAt == null)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}

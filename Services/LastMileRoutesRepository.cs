using Microsoft.EntityFrameworkCore;
using RoutesManagementSystem.API.DbContexts;
using RoutesManagementSystem.API.Entities;

namespace RoutesManagementSystem.API.Services
{
    public class LastMileRoutesRepository : ILastMileRoutesRepository
    {
        private readonly RoutesManagerDbContext _context;

        public LastMileRoutesRepository(RoutesManagerDbContext context) 
        { 
            _context = context;
        }

        public async Task<int> AddLastMileRoute(
            Entities.Route route,
            LastMileRoute lastMileRoute
        )
        {
            route.LastMileRoute = lastMileRoute;
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

        public async Task<RoutesManagementSystem.API.Entities.Route?> GetLastMileRouteById(int id)
        {
           var result = await _context.Routes
                .Include(r => r.LastMileRoute)
                .ThenInclude(l => l.Settlements)
                .Include(r => r.RouteType)
                .Where(r => r.Id == id && r.DeletedAt == null)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result >= 0;
        }
    }
}

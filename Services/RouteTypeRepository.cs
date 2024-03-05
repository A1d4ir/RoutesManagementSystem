using Microsoft.EntityFrameworkCore;
using RoutesManagementSystem.API.DbContexts;
using RoutesManagementSystem.API.Entities;

namespace RoutesManagementSystem.API.Services
{
    public class RouteTypeRepository : IRouteTypeRepository
    {
        private readonly RoutesManagerDbContext _context;

        public RouteTypeRepository(RoutesManagerDbContext context)
        {
            _context = context;
        }
        public async Task<RouteType?> GetRouteTypeAsync(int id)
        {
            var routeType = await _context.RouteTypes.FirstOrDefaultAsync(r => r.Id == id);

            return routeType;
        }
    }
}

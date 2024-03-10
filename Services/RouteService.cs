
using Microsoft.EntityFrameworkCore;
using RoutesManagementSystem.API.DbContexts;

namespace RoutesManagementSystem.API.Services
{
    public class RouteService : IRouteService
    {
        private readonly RoutesManagerDbContext _context;

        public RouteService(RoutesManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Entities.Route?> RouteExist(int id)
        {
            var routeExist = await _context.Routes
                .Where(r => r.Id == id && r.DeletedAt == null)
                .FirstOrDefaultAsync();

            return routeExist;
        }

        public void DeleteRoute(Entities.Route route)
        {
            route.DeletedAt = DateTime.Now;
        }

        public async Task<(IEnumerable<Entities.Route>, PaginationMetadata)> GetRoutesAsync(
            string? name, 
            string? searchQuery, 
            int pageNumber, 
            int pageSize
        )
        {
            // collection to start from
            var collection = _context.Routes as IQueryable<Entities.Route>;

            if(!string.IsNullOrEmpty( name ) )
            {
                name = name.Trim();
                collection = collection.Where( r => r.Name == name );
            }

            if( !string.IsNullOrEmpty( searchQuery ) )
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where( r => r.Name.Contains( searchQuery )
                    || (r.Description != null && r.Description.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy( r => r.Name )
                .Include( r => r.RouteType )
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
            return (collectionToReturn, paginationMetadata);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >  0);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RoutesManagementSystem.API.Entities;

namespace RoutesManagementSystem.API.DbContexts
{
    public class RoutesManagerDbContext : DbContext
    {
        public DbSet<RoutesManagementSystem.API.Entities.Route> Routes { get; set; } = null!;
        public DbSet<LastMileRoute> LastMileRoutes { get; set;} = null!;
        public DbSet<MiddleMileRoute> MiddleMileRoutes { get;set; } = null!;
        public DbSet<RouteType> RouteTypes { get; set; } = null!;
        public DbSet<Settlement> Settlements { get; set; } = null!;

        public RoutesManagerDbContext(DbContextOptions<RoutesManagerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RouteType>()
                .HasData(
                new RouteType("EMD", "Entrega mismo dia")
                {
                    Id = 1
                },
                new RouteType("RAC", "Ruta articulos chicos")
                {
                    Id= 2
                },
                new RouteType("Normal", "Mudancitas")
                {
                    Id = 3
                }
                );
            base.OnModelCreating(modelBuilder);
        }

    }
}

using RoutesManagementSystem.API.Models;

namespace RoutesManagementSystem.API
{
    public class RoutesDataStore
    {
        public List<RouteBaseDto> Routes { get; set; }
        public static RoutesDataStore Current { get; } = new RoutesDataStore();

        public RoutesDataStore()
        {
            Routes = new List<RouteBaseDto>()
            {
                new RouteBaseDto()
                {
                    Id = 1,
                    Name = "Ruta de prueba",
                    Description = "Primera ruta de prueba",
                    Origen = "Origen 1",
                    ProductType = 3,
                    LastMileRouteComplement = new LastMileRouteComplementDto()
                    {
                        RouteId = 1,
                        Destino = "Destino 1",
                        ConfigurationType = "Full"
                    }
                },
                new RouteBaseDto()
                {
                    Id = 2,
                    Name = "Ruta de prueba #2",
                    Description = "Descripcion Ruta de prueba #2",
                    Origen = "Origen 2",
                    ProductType = 3,
                    LastMileRouteComplement = new LastMileRouteComplementDto()
                    {
                        RouteId = 2,
                        Destino = "Destino 2",
                        ConfigurationType = "Secciones"
                    }
                },
                new RouteBaseDto()
                {
                    Id = 3,
                    Name = "Ruta de prueba #3",
                    Description = "Description Route #3",
                    Origen = "Origin 3",
                    ProductType = 3,
                    LastMileRouteComplement = new LastMileRouteComplementDto()
                    {
                        RouteId = 3,
                        Destino = "Destination 3",
                        ConfigurationType = "Full"
                    }
                }
            };
        }
    }
}

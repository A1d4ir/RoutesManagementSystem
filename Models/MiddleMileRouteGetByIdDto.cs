namespace RoutesManagementSystem.API.Models
{
    public class MiddleMileRouteGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BusinessUnit { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public RouteTypeDto? RouteType { get; set; }
        public int ProductType { get; set; }
        public string DestinationBusinessUnit {  get; set; } = string.Empty;
        public int Distance { get; set; }
        public int DeliveryTime { get; set; }
    }
}

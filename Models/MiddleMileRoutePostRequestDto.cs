namespace RoutesManagementSystem.API.Models
{
    public class MiddleMileRoutePostRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string BusinessUnit { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int RouteTypeId { get; set; }
        public int ProductType { get; set; }
        public string DestinationBusinessUnit { get; set; } = string.Empty;
        public int Distance { get; set; }
        public int DeliveryTime { get; set; }
    }
}

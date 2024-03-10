namespace RoutesManagementSystem.API.Models
{
    public class RouteBaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? BusinessUnit { get; set; }
        public string? Description {  get; set; }
        public RouteTypeDto? RouteType { get; set; }
        public int ProductType { get; set; }
    }
}

namespace RoutesManagementSystem.API.Models
{
    public class RouteBaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Origen {  get; set; }
        public int ProductType { get; set; }
        public LastMileRouteComplementDto LastMileRouteComplement { get; set; }
            = new LastMileRouteComplementDto();
    }
}

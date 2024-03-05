﻿namespace RoutesManagementSystem.API.Models
{
    public class LastMileRoutesPostRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string BusinessUnit { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int RouteTypeId { get; set; }
        public int ProductType { get; set; }
        public int Identify { get; set; }
        public int CityId { get; set; }
        public string ConfigurationType {  get; set; } = string.Empty;
        public int MaximumLoads { get; set; }
        public int MinimumLoads { get; set; }
        public int DaysForDelivery { get; set; }
        public ICollection<SettlementDto>? Settlements { get; set; }
    }
}

using RoutesManagementSystem.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoutesManagementSystem.API.Entities
{
    public class LastMileRoute
    {
        [ForeignKey("RouteId")]
        public RoutesManagementSystem.API.Entities.Route? Route { get; set; }
        [Key]
        public int RouteId { get; set; }

        [Required]
        public int Identify { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public ConfigurationType ConfigurationType { get; set; }

        [Required]
        public int MaximumLoads { get; set; }

        [Required]
        public int MinimumLoads { get; set;}

        [Required]
        public int DaysForDelivery { get; set; }

        public ICollection<Settlement> Settlements { get; set; } = new List<Settlement>();
    }
}
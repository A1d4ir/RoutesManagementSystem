using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoutesManagementSystem.API.Entities
{
    public class MiddleMileRoute
    {
        [ForeignKey("RouteId")]
        public virtual RoutesManagementSystem.API.Entities.Route? Route { get; set; }

        [Key]
        public int RoputeId { get; set; }

        [Required]
        [MaxLength(8)]
        public string DestinationBusinessUnit { get; set; }

        [Required]
        public int Distance { get; set; }

        [Required]
        public int DeliveryTime { get; set; }

        public MiddleMileRoute(string destinationBusinessUnit)
        {
            DestinationBusinessUnit = destinationBusinessUnit;
        }
    }
}

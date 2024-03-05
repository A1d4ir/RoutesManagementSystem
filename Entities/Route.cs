using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoutesManagementSystem.API.Entities
{
    public class Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(8)]
        public string BusinessUnit { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [ForeignKey("RouteTypeId")]
        public RouteType? RouteType { get; set; }

        public int RouteTypeId { get; set; }
        public int ProductType { get; set; }

        public LastMileRoute? LastMileRoute { get; set; }

        public MiddleMileRoute? MiddleMileRoute { get; set; }

        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Route(string name, string businessUnit, string description)
        {
            Name = name;
            BusinessUnit = businessUnit;
            Description = description;
        }
    }
}

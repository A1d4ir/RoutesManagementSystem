using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoutesManagementSystem.API.Entities
{
    public class Settlement
    {
        public int Id { get; set; }
        public virtual LastMileRoute? LastMileRoute { get; set; }
        public int SettlementId { get; set; }
    }
}

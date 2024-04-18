using RangeManagementSystem.Data.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RangeManagementSystem.Data.Models
{
    public class Reservation : BaseModel<int>
    {
        public DateTime ReservationDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get;set;}
        public int WeaponId { get; set; }
        public virtual Weapon Weapon { get; set; }
        public int AmmunitionId { get; set; }
        public virtual Ammunition Ammunition { get; set; }

    }
}

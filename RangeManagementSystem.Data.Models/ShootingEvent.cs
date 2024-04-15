using RangeManagementSystem.Data.Common.Models;

namespace RangeManagementSystem.Data.Models
{
    public class ShootingEvent : BaseModel<int>
    {
        public DateTime EventDate {  get; set; }
        public DateTime StartTime {  get; set; }
        public DateTime EndTime {  get; set; }
        public string Description { get; set; }
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

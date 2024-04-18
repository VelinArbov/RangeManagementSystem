namespace RangeManagementSystem.Web.Models
{
    public class ShootingEventViewModel
    {
        public int Id { get; set; }
        public string OrganizerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
    }
}

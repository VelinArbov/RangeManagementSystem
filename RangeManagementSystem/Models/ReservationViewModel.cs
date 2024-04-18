namespace RangeManagementSystem.Web.Models
{
    public class ReservationViewModel
    {
        public Dictionary<int, string>? Weapons { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Dictionary<int, string>? Ammunitions { get; set; }

    }
}

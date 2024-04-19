namespace RangeManagementSystem.Web.Models
{
    public class ReservationDataViewModel
    {
        public DateTime ReservationDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string WeaponType { get; set; }
        public string WeaponCaliber { get; set; }
        public string AmmoType{ get; set; }
        public string AmmoCaliber{ get; set; }
    }
}
